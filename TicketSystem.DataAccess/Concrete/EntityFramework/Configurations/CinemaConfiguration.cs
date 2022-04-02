using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Configurations
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.Property(c => c.CinemaId).IsRequired();

            builder.Property(c => c.CinemaName).IsRequired();
            builder.Property(c => c.CinemaName).HasMaxLength(100);

            builder.Property(c => c.CinemaAddress).IsRequired();
            builder.Property(c => c.CinemaAddress).HasMaxLength(500);

            builder.HasKey(c => c.CinemaId);
            builder.HasMany(c => c.Employees).WithOne(e => e.Cinema).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.Scenes).WithOne(s => s.Cinema).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new Cinema
            {
                CinemaId = 1,
                CinemaName = "Cinemaximum",
                CinemaAddress = "Anteras AVM"
            }, new Cinema
            {
                CinemaId = 2,
                CinemaName = "Deniz Feneri",
                CinemaAddress = "Kızılay"
            });
        }
    }
}
