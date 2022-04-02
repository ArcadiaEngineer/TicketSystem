using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(p => p.PaymentId).IsRequired();
            builder.Property(p => p.CardUserName).IsRequired();
            builder.Property(p => p.CardUserName).HasMaxLength(50);

            builder.Property(p => p.CVV).IsRequired();
            builder.Property(p => p.CVV).HasMaxLength(5);

            builder.Property(p => p.CardDueDate).IsRequired();
            builder.Property(p => p.CardDueDate).HasMaxLength(5);

            builder.Property(p => p.CardId).IsRequired();
            builder.Property(p => p.CardId).HasMaxLength(20);

            builder.Property(p => p.EInvoice).IsRequired();
            builder.Property(p => p.EInvoice).HasMaxLength(1);

            builder.HasKey(p => p.PaymentId);
            builder.HasOne(p => p.Customer).WithMany(c => c.Payments).HasForeignKey(p => p.CustomerId);
        }
    }
}
