using System;
using System.Data.Entity;
using System.Linq;
using warehouse_manager.Models;

namespace warehouse_manager
{
    public class Model : DbContext
    {
        public Model() : base("name=Model")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<SupplyingOrder> SupplyingOrders { get; set; }
        public virtual DbSet<PaymentOrder> PaymentOrders { get; set; }
        public virtual DbSet<ExchangeOrder> ExchangeOrders { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}