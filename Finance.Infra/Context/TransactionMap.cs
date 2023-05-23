using Finance.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.Context
{
    public class TransactionMap
    {
        public TransactionMap(EntityTypeBuilder<Transaction> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("transactions");

            entityTypeBuilder.Property(x => x.Id).HasColumnName("id");
            entityTypeBuilder.Property(x => x.Description).HasColumnName("description");
            entityTypeBuilder.Property(x => x.Value).HasColumnName("value");
            entityTypeBuilder.Property(x => x.Type).HasColumnName("type");
            entityTypeBuilder.Property(x => x.Date).HasColumnName("date");
        }
    }
}
