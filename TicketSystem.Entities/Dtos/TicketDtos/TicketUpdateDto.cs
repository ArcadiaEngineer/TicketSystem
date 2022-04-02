using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class TicketUpdateDto : IDto
    {
        public int TicketId { get; set; }
        public int SessionId { get; set; }
        public int SeatId { get; set; }
        public int CustomerId { get; set; }
        public int StudentNum { get; set; }
        public int AdultNum { get; set; }
        public decimal Price { get; set; }
    }
}
