using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.SystemEntities
{
    public class Payment : IEntity
    {
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public string? CardUserName { get; set; }
        public string? CVV { get; set; }
        public string? CardDueDate { get; set; }
        public string? CardId { get; set; }
        public string? EInvoice { get; set; }
    }
}
