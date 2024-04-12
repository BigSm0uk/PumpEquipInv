using Microsoft.EntityFrameworkCore;
using PumpEquipInv.Core.Domain;

namespace PumpEquipInv.DataAccess;

public sealed class PumpDbContext(DbContextOptions<PumpDbContext> options) : DbContext(options)
{
    public DbSet<Material> Materials { get; set; } = null!;
    public DbSet<Motor> Motors { get; set; } = null!;
    public DbSet<Pump> Pumps { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Motor>()
            .HasMany<Pump>(u => u.Pumps)
            .WithOne(m => m.Motor)
            .HasForeignKey(u=>u.MotorId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        modelBuilder.Entity<Material>()
            .HasMany<Pump>(u => u.Pumps)
            .WithOne(m => m.FrameMaterial)
            .HasForeignKey(u=>u.FrameMaterialId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        modelBuilder.Entity<Material>()
            .HasMany<Pump>(u => u.Pumps)
            .WithOne(m => m.WheelMaterial)
            .HasForeignKey(u=>u.WheelMaterialId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}