using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class PaymentCreateDto : IDto
    {
        public int CustomerId { get; set; }
        public string? CardUserName { get; set; }
        public string? CVV { get; set; }
        public string? CardDueDate { get; set; }
        public string? CardId { get; set; }
        public string? EInvoice { get; set; }
    }
}
