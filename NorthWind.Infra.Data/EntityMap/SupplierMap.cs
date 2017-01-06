﻿using Microsoft.EntityFrameworkCore;
using NorthWind.Domain.Entities;

namespace NorthWind.Infra.Data.EntityMap
{
    public class SupplierMap
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>(entity =>
            {
                //Table Name
                entity.ToTable("Suppliers");

                // Primary Key
                entity.HasKey(e => e.SupplierId).HasName("PK_Suppliers");

                // Indexes
                entity.HasIndex(e => e.CompanyName).HasName("CompanyName");

                entity.HasIndex(e => e.PostalCode).HasName("PostalCode");

                //Column Mappings
                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.Address).HasMaxLength(60);

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ContactName).HasMaxLength(30);

                entity.Property(e => e.ContactTitle).HasMaxLength(30);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.Fax).HasMaxLength(24);

                entity.Property(e => e.HomePage).HasColumnType("ntext");

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.Region).HasMaxLength(15);
            });
        }
    }
}
