using Microsoft.EntityFrameworkCore;
using NorthWind.Domain.Entities;

namespace NorthWind.Infra.Data.EntityMap
{
    public class RegionMap
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>(entity =>
            {
                //Table Name
                entity.HasKey(e => e.RegionId).HasName("PK_Region");

                //Column Mappings
                entity.Property(e => e.RegionId).HasColumnName("RegionID").ValueGeneratedNever();

                entity.Property(e => e.RegionDescription)
                    .IsRequired()
                    .HasColumnType("nchar(50)");
            });
        }
    }
}
