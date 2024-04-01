using BackEnd.Domain.Entities;
using BackEnd.Infra.EntityMapping;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infra.Context;

public class PgContext : DbContext
{

    public PgContext(DbContextOptions<PgContext> options) : base(options)
    { }

    public DbSet<RentalPlan> RentalPlans { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<Couriers> Couriers { get; set; }
    public DbSet<Motorcycle> Motorcycles { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("challengedb");
        builder.ApplyConfiguration(new RentalPlansMap());
        builder.ApplyConfiguration(new OrdersMap());
        builder.ApplyConfiguration(new CouriersMap());
        builder.ApplyConfiguration(new MotorcyclesMap());
        builder.ApplyConfiguration(new RentalsMap());
        builder.ApplyConfiguration(new NotificationsMap());
    }

}
