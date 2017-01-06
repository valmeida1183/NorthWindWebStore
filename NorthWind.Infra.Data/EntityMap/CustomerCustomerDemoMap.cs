using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NorthWind.Domain.Entities;

namespace NorthWind.Infra.Data.EntityMap
{
    public class CustomerCustomerDemoMap
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerCustomerDemo>(entity =>
            {
                // Primary Key
                entity.HasKey(e => new { e.CustomerId, e.CustomerTypeId }).HasName("PK_CustomerCustomerDemo");

                //Column Mappings
                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasColumnType("nchar(5)");

                entity.Property(e => e.CustomerTypeId)
                    .HasColumnName("CustomerTypeID")
                    .HasColumnType("nchar(10)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerCustomerDemo)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CustomerCustomerDemo_Customers");

                entity.HasOne(d => d.CustomerType)
                    .WithMany(p => p.CustomerCustomerDemo)
                    .HasForeignKey(d => d.CustomerTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CustomerCustomerDemo");
            });
        }
    }
}
