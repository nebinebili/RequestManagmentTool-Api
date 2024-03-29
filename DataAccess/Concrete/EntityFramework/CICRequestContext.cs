﻿using DataAccess.EntityConfiguration;
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
    public class CICRequestContext : DbContext
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
            modelBuilder.ApplyConfiguration(new CommentConfiguration());

            modelBuilder.Entity<Request>().HasOne(r => r.Executor).WithMany(e => e.ExecutorRequests).HasForeignKey(r => r.ExecutorId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Request>().HasOne(r => r.Sender).WithMany(e => e.SenderRequests).HasForeignKey(r => r.SenderId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Request>().HasOne(r => r.RequestInfo).WithOne(e => e.Request).HasForeignKey<RequestInfo>(r => r.RequestId);
            modelBuilder.Entity<Entities.Concrete.File>().HasOne(f => f.User).WithOne(u => u.File).HasForeignKey<User>(u => u.ImageId);
            modelBuilder.Entity<Entities.Concrete.File>().HasOne(f => f.Comment).WithOne(c => c.File).HasForeignKey<Comment>(c => c.CFileId);
            modelBuilder.Entity<Entities.Concrete.File>().HasOne(f => f.Request).WithOne(r => r.File).HasForeignKey<Request>(r => r.RFileId);

           
            SeedData.Data(modelBuilder);
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
        public DbSet<CategoryUser> CategoryUsers { get; set; }
        public DbSet<NonWorkingDay> NonWorkingDays { get; set; }
        public DbSet<Entities.Concrete.File> Files { get; set; }

    }
}
