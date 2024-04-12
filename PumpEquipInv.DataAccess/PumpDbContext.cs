using Microsoft.EntityFrameworkCore;
using PumpEquipInv.Core.Domain;

namespace PumpEquipInv.DataAccess;

public partial class PumpDbContext(DbContextOptions<PumpDbContext> options) : DbContext(options)
{
    public virtual required DbSet<Material> Materials { get; init; }

    public virtual required DbSet<Motor> Motors { get; init; }

    public virtual required DbSet<Pump> Pumps { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.id).HasName("materials_pkey");

            entity.Property(e => e.id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Motor>(entity =>
        {
            entity.HasKey(e => e.id).HasName("motors_pkey");

            entity.Property(e => e.id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Pump>(entity =>
        {
            entity.HasKey(e => e.id).HasName("pumps_pkey");

            entity.Property(e => e.id).ValueGeneratedNever();

            entity.HasOne(d => d.framematerial).WithMany(p => p.pumpframematerials)
                .HasConstraintName("pumps_framematerialid_fkey");

            entity.HasOne(d => d.motor).WithMany(p => p.pumps).HasConstraintName("pumps_motorid_fkey");

            entity.HasOne(d => d.wheelmaterial).WithMany(p => p.pumpwheelmaterials)
                .HasConstraintName("pumps_wheelmaterialid_fkey");
        });
    }
}