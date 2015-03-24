using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AppTier.Models.Mapping;

namespace AppTier.Models
{
    public partial class NorthwindContext : DbContext
    {
        static NorthwindContext()
        {
            Database.SetInitializer<NorthwindContext>(null);
        }

        public NorthwindContext()
            : base("Name=NorthwindContext")
        {
        }

        public DbSet<Order_Detail> Order_Details { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Order_DetailMap());
            modelBuilder.Configurations.Add(new OrderMap());
        }
    }
}
