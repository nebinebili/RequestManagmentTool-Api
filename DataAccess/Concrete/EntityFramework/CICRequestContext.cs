using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CICRequestContext:DbContext
    {
        public CICRequestContext(DbContextOptions contextOptions):base(contextOptions)
        {
            
        }

       public DbSet<User> Users { get; set; }
    }
}
