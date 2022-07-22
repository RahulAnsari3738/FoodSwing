
using DbAccess.DbClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DbAccess.DbClasses;


namespace DbAccess.DatabaseContext
{
    public class FoodSwingContext : IdentityDbContext<IdentityUser>
    {
        public FoodSwingContext(DbContextOptions<FoodSwingContext> options)
            : base(options)
        { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<Customer> customers { get; set; }





    }
}