using Domain.Wheel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class DatabaseContext : DbContext
{
    public DbSet<WheelList> WheelLists { get; set; }
    public DbSet<WheelItem> WheelItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WheelList>().HasKey(x => x.Guid);
        modelBuilder.Entity<WheelItem>().HasKey(x => x.Guid);

        modelBuilder.Entity<WheelItem>()
            .HasOne(x => x.List)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.ListGuid)
            .OnDelete(DeleteBehavior.NoAction);
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
