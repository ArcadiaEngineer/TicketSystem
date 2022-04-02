using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.SystemEntities
{
    public class Scene : IEntity
    {
        public int SceneId { get; set; }
        public int CinemaId { get; set; }
        public Cinema? Cinema { get; set; }
        public string? SceneName { get; set; }
        public string? SceneType { get; set; }
        public List<Seat>? Seats { get; set; }
    }
}
