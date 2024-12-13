using Microsoft.EntityFrameworkCore;
using TrackFlow.Entities;

namespace TrackFlow.Data
{
    public class ContextTrackFlow(DbContextOptions<ContextTrackFlow> options) : DbContext(options)
    {
        public virtual DbSet<Vehicle>? Vehicles { get; set; }
        public virtual DbSet<Driver>? Drivers { get; set; }
        public virtual DbSet<Itenerary>? Iteneraries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Vehicle
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(v => v.Registration);

                entity.Property(v => v.Registration).HasMaxLength(10).IsUnicode(false);
                entity.Property(v => v.Fuel).HasMaxLength(10).IsUnicode(false);

            });
            #endregion

            #region Driver
            modelBuilder.Entity<Driver>(entity => 
            {
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Firstname).HasMaxLength(10).IsUnicode(false);
                entity.Property(d => d.Lastname).HasMaxLength(10).IsUnicode(false);

                //fk 
                entity.HasMany<Vehicle>().WithMany().UsingEntity<Itenerary>
                (
                    l => l.HasOne<Vehicle>().WithMany().HasForeignKey(fk => fk.VehicleId),
                    r => r.HasOne<Driver>().WithMany().HasForeignKey(fk => fk.DriverId)
                );
            });
            #endregion

            #region Itenerary
            modelBuilder.Entity<Itenerary>(entity => 
            {
                // Primary Key
                entity.HasKey(i => new { i.DriverId, i.VehicleId });

                entity.Property(i => i.VehicleId).HasMaxLength(10).IsUnicode(false);
                entity.Property(i => i.DriverId).HasMaxLength(10).IsUnicode(false);
            });
            #endregion
        }
    }
}
