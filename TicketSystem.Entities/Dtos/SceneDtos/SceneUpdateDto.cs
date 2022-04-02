using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class SceneUpdateDto : IDto
    {
        public int SceneId { get; set; }
        public int CinemaId { get; set; }
        public string? SceneName { get; set; }
        public string? SceneType { get; set; }
    }
}
