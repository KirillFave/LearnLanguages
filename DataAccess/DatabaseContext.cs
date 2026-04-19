using Domain.Schemes;
using Domain.Wheel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class DatabaseContext : DbContext
{
    public DbSet<WheelList> WheelLists { get; set; }
    public DbSet<WheelItem> WheelItems { get; set; }

    public DbSet<Scheme> Schemes { get; set; }
    public DbSet<SchemeItem> SchemeItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WheelList>(e =>
        {
            e.HasKey(x => x.Guid);
        });

        modelBuilder.Entity<WheelItem>(e =>
        {
            e.HasKey(x => x.Guid);
            e.HasOne(x => x.List)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.ListGuid)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Scheme>(e =>
        {
            e.HasKey(x => x.Guid);
        });

        modelBuilder.Entity<SchemeItem>(e =>
        {
            e.HasKey(x => x.Guid);
            e.HasOne(x => x.Scheme)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.SchemeGuid)
                .OnDelete(DeleteBehavior.NoAction);
        });
    }

    public DatabaseContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlite("Data Source=LearnLanguages.db");
    }
}
