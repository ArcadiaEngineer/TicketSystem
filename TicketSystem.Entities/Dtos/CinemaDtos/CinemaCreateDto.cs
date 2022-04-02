using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class CinemaCreateDto : IDto
    {
        public string? CinemaName { get; set; }
        public string? CinemaAddress { get; set; }
    }
}
