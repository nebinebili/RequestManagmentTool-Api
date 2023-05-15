using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Entities.Concrete.Type;

namespace DataAccess
{
    public static class SeedData
    {
        public static void Data(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Name = "Açıq" },
                new Status { Id = 2, Name = "İcrada" },
                new Status { Id = 3, Name = "Qapalı" },
                new Status { Id = 4, Name = "Təsdiqləndi" },
                new Status { Id = 5, Name = "İmtina edildi" },
                new Status { Id = 6, Name = "Gözləmədə" }
            );

            modelBuilder.Entity<RequestType>().HasData(
                 new RequestType { Id = 1, Name = "App Change" },
                 new RequestType { Id = 2, Name = "App Issue" },
                 new RequestType { Id = 3, Name = "App New Requirement" },
                 new RequestType { Id = 4, Name = "Change the Report" },
                 new RequestType { Id = 5, Name = "Create Custom Report" },
                 new RequestType { Id = 6, Name = "Create New Report" },
                 new RequestType { Id = 7, Name = "Incident" },
                 new RequestType { Id = 8, Name = "Master Data Change" },
                 new RequestType { Id = 9, Name = "Service Request" }
             );

            modelBuilder.Entity<Priority>().HasData(
                new Priority { Id = 1, Name = "Low" },
                new Priority { Id = 2, Name = "Medium" },
                new Priority { Id = 3, Name = "Hard" }
             );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "3E-Agis" },
                new Category { Id = 2, Name = "3E dəstək" },
                new Category { Id = 3, Name = "Call Center" },
                new Category { Id = 4, Name = "azkob.az" },
                new Category { Id = 5, Name = "cic web site" },
                new Category { Id = 6, Name = "Azeriqaz sms" },
                new Category { Id = 7, Name = "ailem.socar.az" },
                new Category { Id = 8, Name = "Asan web service" }
             );

            modelBuilder.Entity<Contact>().HasData(
                new Contact { Id=1,Name="Email"},
                new Contact { Id=2,Name="Phone"},
                new Contact { Id=3,Name="SOLMAN"},
                new Contact { Id=4,Name="Request"}
                );

            modelBuilder.Entity<Type>().HasData(
                new Type { Id = 1, Name="Application Maintenance"},
                new Type { Id = 2, Name="Application Development"}
                );

            modelBuilder.Entity<Request>().HasData(
                new Request { Id = 1, Title = "#email Test", Text = "email test edilme isi", CategoryId = 3, StatusId = 2, PriorityId = 1, RequestTypeId = 5, SenderId = 1 },
                new Request { Id = 2, Title = "Odenislerin silinmesi", Text = "odenislerin silinmesi emeliyyati", CategoryId = 2, StatusId = 1, PriorityId = 3, RequestTypeId = 2, SenderId = 3, ExecutorId = 1 },
                new Request { Id = 3, Title = "Odenislerin arasdirilimasi", Text = "odenislerin arasdirilimasi emeliyyati", CategoryId = 4, StatusId = 1, PriorityId = 2, RequestTypeId = 5, SenderId = 3, ExecutorId = 2 },
                new Request { Id = 4, Title = "email egov", Text = "email egov emeliyyati", CategoryId = 5, StatusId = 3, PriorityId = 2, RequestTypeId = 7, SenderId = 2 },
                new Request { Id = 5, Title = "muqavile", Text = "muqavile emeliyyati", CategoryId = 4, StatusId = 3, PriorityId = 2, RequestTypeId = 3, SenderId = 1, ExecutorId = 3 }
                );

            // User 1 category3 create=true  exceute=false
            // User 1  category2  create=false    execute=true
            // User 1  category4  create=true    execute=true
            // User 2 category4  create=false  execite=true
            // User 2 category5  create=true  execite=false
            // User3  category2    create=true   execute=false
            // User3  category4    create=true   execute=true
        }
    }
}
