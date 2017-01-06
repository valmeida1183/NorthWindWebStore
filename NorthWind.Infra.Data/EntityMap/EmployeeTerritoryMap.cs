using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NorthWind.Domain.Entities;

namespace NorthWind.Infra.Data.EntityMap
{
    public class EmployeeTerritoryMap
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTerritory>(entity =>
            {
                //Table Name
                entity.ToTable("EmployeeTerritories");

                // Primary Key
                entity.HasKey(e => new { e.EmployeeId, e.TerritoryId }).HasName("PK_EmployeeTerritories");

                //Column Mappings
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.TerritoryId)
                    .HasColumnName("TerritoryID")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeTerritories)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EmployeeTerritories_Employees");

                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.EmployeeTerritories)
                    .HasForeignKey(d => d.TerritoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EmployeeTerritories_Territories");
            });
        }
    }
}
