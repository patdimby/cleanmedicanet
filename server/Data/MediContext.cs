using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data;

public class MediContext : DbContext
{
    public MediContext()
    {
        Database.Migrate();
        // Or Database.EnsureCreated();
    }

    public MediContext(DbContextOptions<MediContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Model configuration
        // modelBuilder.Entity<CartItem>().HasKey(x => new { x.CartId, x.ProductId })

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "server=mysql-medicanet-medica-net.k.aivencloud.com; port=18347; database=defaultdb; user=avnadmin; password=; Persist Security Info=False; Connect Timeout=300";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<Title> Titles { get; set; }
}