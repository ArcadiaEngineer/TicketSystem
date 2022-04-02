using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Configurations
{
    public class SceneConfiguration : IEntityTypeConfiguration<Scene>
    {
        public void Configure(EntityTypeBuilder<Scene> builder)
        {
            builder.Property(s => s.SceneId).IsRequired();

            builder.Property(s => s.SceneName).IsRequired();
            builder.Property(s => s.SceneName).HasMaxLength(10);

            builder.Property(s => s.SceneType).IsRequired();
            builder.Property(s => s.SceneType).HasMaxLength(10);

            builder.HasKey(s => s.SceneId);
            builder.HasOne(s => s.Cinema).WithMany(c => c.Scenes).HasForeignKey(s => s.SceneId);

            builder.HasMany(sc => sc.Seats).WithOne(s => s.Scene).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
