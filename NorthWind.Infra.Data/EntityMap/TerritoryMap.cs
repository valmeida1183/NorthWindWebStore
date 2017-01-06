using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NorthWind.Domain.Entities;

namespace NorthWind.Infra.Data.EntityMap
{
    public class TerritoryMap
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Territory>(entity =>
            {
                //Table Name
                entity.ToTable("Territories");

                // Primary Key
                entity.HasKey(e => e.TerritoryId)
                    .HasName("PK_Territories");

                //Column Mappings
                entity.Property(e => e.TerritoryId)
                    .HasColumnName("TerritoryID")
                    .HasMaxLength(20);

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.TerritoryDescription)
                    .IsRequired()
                    .HasColumnType("nchar(50)");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Territories)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Territories_Region");
            });
        }
    }
}
