using App.Data.IRepository;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
    {

    }
}
}
