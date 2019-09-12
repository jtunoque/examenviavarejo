using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.IRepository
{
    public interface IAppUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; set; }
       
        int Complete();

    }
}
