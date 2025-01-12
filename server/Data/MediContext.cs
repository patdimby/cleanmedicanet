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
        string connectionString = "server=localhost; port=3306; database=defaultdb; user=sa; password=Ma$terkey1; Persist Security Info=False; Connect Timeout=300";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<Title> Titles { get; set; }
}