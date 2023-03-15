using DataAccess.EntityConfiguration;
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
        public CICRequestContext(DbContextOptions<CICRequestContext> contextOptions) : base(contextOptions)
        {

        }

     
        public CICRequestContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new QueryConfiguration());
            modelBuilder.ApplyConfiguration(new QueryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<QueryType> QueryTypes { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
