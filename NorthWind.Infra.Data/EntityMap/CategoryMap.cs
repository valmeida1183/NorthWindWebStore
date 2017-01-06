using Microsoft.EntityFrameworkCore;
using NorthWind.Domain.Entities;

namespace NorthWind.Infra.Data.EntityMap
{
    public class CategoryMap
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                //Table Name
                entity.ToTable("Categories");

                // Primary Key
                entity.HasKey(e => e.CategoryId).HasName("PK_Categories");

                // Indexes
                entity.HasIndex(e => e.CategoryName).HasName("CategoryName");

                // Propertties
                entity.Property(e => e.CategoryName).IsRequired().HasMaxLength(15);

                //Column Mappings

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Picture).HasColumnType("image");
            });
        }
    }
}
