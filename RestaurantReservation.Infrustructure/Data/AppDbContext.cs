using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Infrustructure.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
                .Ignore(o => o.TotalAmount)
                .HasKey(x => x.OrderID);

        modelBuilder.Entity<Order>()
            .HasOne(t => t.reservation)
            .WithMany(r => r.Orders)
            .HasForeignKey(t => t.ReservationID);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.employee)
            .WithMany(e => e.Orders)
            .HasForeignKey(o => o.EmployeeID);

        modelBuilder.Entity<Customer>()
            .HasKey(x => x.CustomerID);


        modelBuilder.Entity<MenuItem>()
            .HasKey(x => x.MenuItemID);

        modelBuilder.Entity<MenuItem>()
            .HasOne(t => t.Restaurant)
            .WithMany(r => r.MenuItems)
            .HasForeignKey(t => t.RestaurantID);

        modelBuilder.Entity<Employee>()
            .HasKey(x => x.EmployeeID);

        modelBuilder.Entity<Employee>()
            .HasOne(t => t.Restaurant)
            .WithMany(r => r.Employees)
            .HasForeignKey(t => t.RestaurantID);


        modelBuilder.Entity<OrderItem>()
            .HasKey(x => x.OrderItemID);

        modelBuilder.Entity<OrderItem>()
            .HasOne(t => t.Order)
            .WithMany(r => r.OrderItems)
            .HasForeignKey(t => t.OrderID);

        modelBuilder.Entity<OrderItem>()
            .HasOne(t => t.Item)
            .WithMany(r => r.OrderItems)
            .HasForeignKey(t => t.MenuItemID);

        modelBuilder.Entity<Reservation>()
            .HasKey(x => x.ReservationID);

        modelBuilder.Entity<Reservation>()
            .HasOne(t => t.restaurant)
            .WithMany(r => r.Reservations)
            .HasForeignKey(t => t.RestaurantID);

        modelBuilder.Entity<Reservation>()
            .HasOne(t => t.customer)
            .WithMany(r => r.Reservations)
            .HasForeignKey(t => t.CustomerID);

        modelBuilder.Entity<Reservation>()
            .HasOne(t => t.Table)
            .WithMany(r => r.Reservations)
            .HasForeignKey(t => t.TableID);

        modelBuilder.Entity<Restaurant>()
            .HasKey(x => x.RestaurantID);

        modelBuilder.Entity<Table>()
            .HasKey(x => x.TableID);

        modelBuilder.Entity<Table>()
            .HasOne(t => t.Restaurant)
            .WithMany(r => r.Tables)
            .HasForeignKey(t => t.RestaurantID);

        var cascadeDeleteFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var FK in cascadeDeleteFKs)
            FK.DeleteBehavior = DeleteBehavior.NoAction;
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Table> Tables { get; set; }
}