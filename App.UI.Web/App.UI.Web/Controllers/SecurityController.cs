using App.Data.IRepository;
using App.Data.Repository;
using App.Infraestructure.Security;
using App.UI.Web.Helpers;
using App.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.Controllers
{
    [Authorize]
    public class SecurityController : Controller
    {

        private readonly IAppUnitOfWork uw = null;
        public SecurityController()
        {
            uw = new AppUnitOfWork();
        }

        [AllowAnonymous]
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {

            //Verificar en la base de datos
            var userFound = uw.UserRepository.GetAll(item => item.Email == model.Login).FirstOrDefault();
            uw.Dispose();            

            if (userFound != null)
            {

                if (!SecurityInfra.VerifyHashedPassword(userFound.SenhaHash,model.Password))
                {
                    model.MensajeValidacion = "Autentication error";
                    return View(model);
                }

               //Ingreso a la aplicación
               var claims = SecurityHelpers.CreateClaimsUsuario(userFound);
                var identity = new ClaimsIdentity(claims, "ApplicationCookie");
                var context = Request.GetOwinContext();
                var authManager = context.Authentication;
                authManager.SignIn(identity);

                return Redirect(model.ReturnUrl ?? "~/");
            }
            else
            {
                model.MensajeValidacion = "Usuario no registrado en el sistema";
                return View(model);
            }

           
        }

        public ActionResult SignOut()
        {
            Request.GetOwinContext().Authentication.SignOut();

            return RedirectToAction("Login");
        }
    }
}