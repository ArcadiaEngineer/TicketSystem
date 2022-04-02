using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class SceneCreateDto : IDto
    {
        public int CinemaId { get; set; }
        public string? SceneName { get; set; }
        public string? SceneType { get; set; }
    }
}
