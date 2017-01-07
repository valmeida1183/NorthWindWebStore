using Microsoft.EntityFrameworkCore;
using NorthWind.Domain.Entities;
using NorthWind.Infra.Data.EntityMap;

namespace Infra.Data.Context
{
    public partial class NorthWindContext : DbContext
    {
        public NorthWindContext(DbContextOptions<NorthWindContext> options) : base(options)
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
        public virtual DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //optionsBuilder.UseSqlServer(@"Server=VINICIUS_NOTE\VINICIUS;Database=northwind;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CategoryMap.Configure(modelBuilder);
            ContactMap.Configure(modelBuilder);
            CustomerCustomerDemoMap.Configure(modelBuilder);
            CustomerDemographicMap.Configure(modelBuilder);
            CustomerMap.Configure(modelBuilder);
            EmployeeMap.Configure(modelBuilder);
            EmployeeTerritoryMap.Configure(modelBuilder);
            OrderDetailMap.Configure(modelBuilder);
            OrderMap.Configure(modelBuilder);
            ProductMap.Configure(modelBuilder);
            RegionMap.Configure(modelBuilder);
            ShipperMap.Configure(modelBuilder);
            SupplierMap.Configure(modelBuilder);
            TerritoryMap.Configure(modelBuilder);              
        }
    }
}
