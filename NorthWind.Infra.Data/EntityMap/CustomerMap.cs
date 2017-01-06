﻿using Microsoft.EntityFrameworkCore;
using NorthWind.Domain.Entities;

namespace NorthWind.Infra.Data.EntityMap
{
    public class CustomerMap
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                //Table Name
                entity.ToTable("Customers");

                // Primary Key
                entity.HasKey(e => e.CustomerId).HasName("PK_Customers");

                // Indexes
                entity.HasIndex(e => e.City).HasName("City");

                entity.HasIndex(e => e.CompanyName).HasName("CompanyName");

                entity.HasIndex(e => e.PostalCode).HasName("PostalCode");

                entity.HasIndex(e => e.Region).HasName("Region");


                //Column Mappings
                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasColumnType("nchar(5)");

                entity.Property(e => e.Address).HasMaxLength(60);

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ContactName).HasMaxLength(30);

                entity.Property(e => e.ContactTitle).HasMaxLength(30);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.Fax).HasMaxLength(24);

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.Region).HasMaxLength(15);
            });
        }
    }
}
