using Core;
using Core.Model.FinancesModel;
using Core.Model.MenuModel;
using Core.Model.OrderModel;
using Core.Model.PromoCodeModel;
using Core.Model.ReservationModel;
using Core.Model.RestaurantModel;
using Core.Model.ScheduleModel;
using Core.Model.ServicesModel;
using Core.Model.StaffModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL;

internal sealed class RestauratorDbContext : DbContext
{
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Employee> Employees { get; set; }

    /// <summary>
    /// Menu
    /// </summary>
    public DbSet<Menu> Menus { get; set; }

    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }

    /// <summary>
    /// Orders
    /// </summary>
    public DbSet<Order> Orders { get; set; }

    public DbSet<RestaurantOrder> RestaurantOrders { get; set; }
    public DbSet<TakeAwayOrder> TakeAwayOrders { get; set; }
    public DbSet<DeliveryOrder> DeliveryOrders { get; set; }

    public DbSet<Service> Services { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    /// <summary>
    /// Schedules
    /// </summary>
    public DbSet<DailyEmployeeSchedule> DailyEmployeeSchedules { get; set; }

    public DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }

    /// <summary>
    /// Promo Codes
    /// </summary>
    public DbSet<PromoCode> PromoCodes { get; set; }

    public DbSet<DayOfWeekPromoCode> DayOfWeekPromoCodes { get; set; }
    public DbSet<RangeDatePromoCode> RangeDatePromoCodes { get; set; }
    public DbSet<SpecificDatePromoCode> SpecificDatePromoCodes { get; set; }

    /// <summary>
    /// Receipts
    /// </summary>
    public DbSet<Receipt> Receipts { get; set; }

    public DbSet<ReceiptRow> ReceiptRows { get; set; }
    public DbSet<MenuItemReceiptRow> MenuItemReceiptRows { get; set; }
    public DbSet<ServiceReceiptRow> ServiceReceiptRows { get; set; }

    public RestauratorDbContext(DbContextOptions<RestauratorDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public override int SaveChanges()
    {
        HandleSoftDelete();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        HandleSoftDelete();
        return base.SaveChangesAsync(cancellationToken);
    }
    
    private void HandleSoftDelete()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is ISoftDelete softDelete && entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                softDelete.SoftDelete();
            }
        }
        
    }
}