using App.Data.IRepository;
using App.Data.Repository;
using App.Entities.Base;
using App.Infraestructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App.UI.WebApi.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly IAppUnitOfWork uw = null;
        public UsuarioController()
        {
            uw = new AppUnitOfWork();
        }

        public IEnumerable<User> Get([FromUri] string name=null)
        {
            name = name ?? "";
            return this.uw.UserRepository.GetAll(item=>item.Nome.Contains(name)).ToList();
        }

        public User Get(int id)
        {
            var userInfo = this.uw.UserRepository.GetById(id);
            userInfo.SenhaHash = "";
            return this.uw.UserRepository.GetById(id);
        }

        public bool Patch(User model)
        {
            model.SenhaHash = SecurityInfra.HashPassword(model.SenhaHash);
            model.Roles = "user";
            uw.UserRepository.Update(model);
            var result = uw.Complete() > 0;

            return result;
        }
        public bool Delete(User model)
        {
            uw.UserRepository.Remove(model);
            var result = uw.Complete() > 0;
            //var result = true;
            return result;
        }

        public bool Put(User model)
        {
            model.SenhaHash = SecurityInfra.HashPassword(model.SenhaHash);
            model.Roles = "user";
            uw.UserRepository.Add(model);
            var result =uw.Complete()>0;            

            return result;
        }

    }
}
