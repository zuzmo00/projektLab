using System.Reflection.Emit;
using teremKezelo.Entities;
using Microsoft.EntityFrameworkCore;

namespace teremKezelo.DbCOntext
{
    public class AppDbContext: DbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ResourceCategory> ResourceCategories { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<MaintenancePeriod> MaintenancePeriods { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Felhasználó (ApplicationUser) 1 - N Foglalás (Reservation)
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Reservations)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict, hogy ne töröljünk usert, ha van foglalása

            // Erőforrás (Resource) 1 - N Foglalás (Reservation)
            modelBuilder.Entity<Resource>()
                .HasMany(r => r.Reservations)
                .WithOne(res => res.Resource)
                .HasForeignKey(res => res.ResourceId)
                .OnDelete(DeleteBehavior.Cascade); // Ha törlünk egy erőforrást, törlődhetnek a foglalásai (vagy használhatsz Restrict-et)

            // Helyszín (Location) 1 - N Erőforrás (Resource)
            modelBuilder.Entity<Location>()
                .HasMany(l => l.Resources)
                .WithOne(r => r.Location)
                .HasForeignKey(r => r.LocationId)
                .OnDelete(DeleteBehavior.SetNull); // Mivel a LocationId nullable a közös Resource modellben

            // Kategória (ResourceCategory) 1 - N Erőforrás (Resource)
            modelBuilder.Entity<ResourceCategory>()
                .HasMany(c => c.Resources)
                .WithOne(r => r.Category)
                .HasForeignKey(r => r.CategoryId)
                .OnDelete(DeleteBehavior.SetNull); // Mivel a CategoryId nullable

            // Erőforrás (Resource) 1 - N Karbantartási időszak (MaintenancePeriod)
            modelBuilder.Entity<Resource>()
                .HasMany(r => r.MaintenancePeriods)
                .WithOne(m => m.Resource)
                .HasForeignKey(m => m.ResourceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
