using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class TicketCreateDto : IDto
    {
        public int SessionId { get; set; }
        public int SeatId { get; set; }
        public int CustomerId { get; set; }
        public int StudentNum { get; set; }
        public int AdultNum { get; set; }
        public decimal Price { get; set; }
    }
}
