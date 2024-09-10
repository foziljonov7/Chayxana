using Chayxana.Domain.Entities.Branches;
using Chayxana.Domain.Entities.Products;
using Chayxana.Domain.Entities.Rooms;
using Chayxana.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Chayxana.DAL.Data.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    //Users DbSet
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Revenue> Revenues { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    //Rooms DbSet
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Booking { get; set; }

    //Products DbSet
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    //Branches DbSet
    public DbSet<Branch> Branches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}