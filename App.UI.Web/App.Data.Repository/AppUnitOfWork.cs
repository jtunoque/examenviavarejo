using App.Data.DataContext;
using App.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class AppUnitOfWork : IAppUnitOfWork, IDisposable
    {

        private readonly DbContext _context;

        public AppUnitOfWork()
        {
            _context = new DataContextDB();
            CreateRepositories();
        }

        public AppUnitOfWork(DbContext context)
        {
            _context = context;
            CreateRepositories();
        }

        private void CreateRepositories()
        {
            this.UserRepository = new UserRepository(_context);
        }

        public IUserRepository UserRepository { get; set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
