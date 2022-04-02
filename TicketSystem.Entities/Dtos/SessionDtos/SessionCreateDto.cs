using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class SessionCreateDto : IDto
    {
        public int MovieId { get; set; }
        public DateTime SessionTime { get; set; }
        public int SessionHour { get; set; }
    }
}
