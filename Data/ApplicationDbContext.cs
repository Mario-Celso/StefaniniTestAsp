using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StefaniniTestAsp.Models;

namespace StefaniniTestAsp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Athlete> Athletes { get; set; }

        public override int SaveChanges()
        {
            ConvertDateTimesToUtc();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ConvertDateTimesToUtc();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ConvertDateTimesToUtc()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                foreach (var property in entry.Properties)
                {
                    if (property.CurrentValue is DateTime dateTime)
                    {
                        property.CurrentValue = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
                    }
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
               v => DateTime.SpecifyKind(v, DateTimeKind.Utc),
               v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
            );

            modelBuilder.Entity<Athlete>()
                .Property(e => e.BirthDate)
                .HasConversion(dateTimeConverter);

            modelBuilder.Entity<Athlete>()
            .Property(a => a.Id)
            .ValueGeneratedOnAdd();
        }
    }
}
