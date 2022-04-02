﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(s => s.SessionId).IsRequired();
            builder.Property(s => s.SessionTime).IsRequired();
            builder.Property(s => s.SessionHour).IsRequired();
            builder.Property(s => s.SessionHour).HasMaxLength(5);

            builder.HasKey(s => s.SessionId);
            builder.HasOne(s => s.Movie).WithMany(m => m.Sessions).HasForeignKey(s => s.MovieId);

            builder.HasMany(s => s.Tickets).WithOne(t => t.Session).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
