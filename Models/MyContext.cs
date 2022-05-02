using Microsoft.EntityFrameworkCore;
namespace SneakEasy.Models
{ 
    public class MyContext : DbContext 
    { 
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Sneaker> Sneakers {get;set;}
        public DbSet<Order> Orders {get;set;}
    }
}