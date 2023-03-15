using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration
{
    public class QueryTypeConfiguration : IEntityTypeConfiguration<QueryType>
    {
        public void Configure(EntityTypeBuilder<QueryType> builder)
        {
            builder.Property(u => u.Name).HasMaxLength(50);
        }
    }
}
