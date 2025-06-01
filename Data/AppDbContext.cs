using ISSAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ISSAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<Channel> Channels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Data Source=iss.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // many-to-many User -> Review <- Show
        modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Show)
            .WithMany(s => s.Reviews)
            .HasForeignKey(r => r.ShowId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // one-to-many Channel -> Show
        modelBuilder.Entity<Channel>()
            .HasMany(c => c.Shows)
            .WithOne(s => s.Channel)
            .HasForeignKey(s => s.ChannelId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}