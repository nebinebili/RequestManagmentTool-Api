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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new QueryConfiguration());
            modelBuilder.ApplyConfiguration(new QueryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.Entity<Query>().HasOne(q=>q.Creator).WithMany(e=>e.CreatorQueries).HasForeignKey(q=>q.CreatorId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Query>().HasOne(q=>q.Sender).WithMany(e=>e.SenderQueries).HasForeignKey(q=>q.SenderId).IsRequired(false).OnDelete(DeleteBehavior.NoAction); 
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<QueryType> QueryTypes { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
