using Microsoft.EntityFrameworkCore;
using NorthWind.Domain.Entities;

namespace NorthWind.Infra.Data.EntityMap
{
    public class CustomerDemographicMap
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDemographic>(entity =>
            {
                //Table Name
                entity.ToTable("CustomerDemographics");

                // Primary Key
                entity.HasKey(e => e.CustomerTypeId).HasName("PK_CustomerDemographics");

                entity.Property(e => e.CustomerTypeId)
                    .HasColumnName("CustomerTypeID")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.CustomerDesc).HasColumnType("ntext");
            });
        }
    }
}
