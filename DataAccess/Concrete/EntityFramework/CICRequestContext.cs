using Core.Entities.Concrete;
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
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new RequestTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.Entity<Request>().HasOne(q=>q.Executor).WithMany(e=>e.ExecutorRequests).HasForeignKey(q=>q.ExecutorId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Request>().HasOne(q=>q.Sender).WithMany(e=>e.SenderRequests).HasForeignKey(q=>q.SenderId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

            
        }



        public DbSet<User> Users { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }

    }
}
