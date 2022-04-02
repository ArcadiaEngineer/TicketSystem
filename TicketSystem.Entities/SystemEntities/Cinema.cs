using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.SystemEntities
{
    public class Cinema : IEntity
    {
        public int CinemaId { get; set; }
        public string? CinemaName { get; set; }
        public string? CinemaAddress { get; set; }
        public List<Employee>? Employees { get; set; }
        public List<Scene>? Scenes { get; set; }
    }
}
