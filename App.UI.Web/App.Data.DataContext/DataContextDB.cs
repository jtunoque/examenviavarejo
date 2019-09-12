using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DataContext
{
    public class DataContextDB : DbContext
    {
        public DataContextDB()
           : base("name=cnxDB")
        {
            Database.SetInitializer<DataContextDB>(null);
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<User> User { get; set; }
    }
}
