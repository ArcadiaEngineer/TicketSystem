using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Configurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.Property(s => s.SeatId).IsRequired();
            builder.Property(s => s.SeatNumber).IsRequired();
            builder.Property(s => s.SeatRow).IsRequired();

            builder.HasKey(s => s.SeatId);
            builder.HasOne(s => s.Scene).WithMany(sc => sc.Seats).HasForeignKey(s => s.SceneId);

            builder.HasMany(s => s.Tickets).WithOne(t => t.Seat).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
