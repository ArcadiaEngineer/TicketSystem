using TicketSystem.Core.Utilities.Results;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Abstract
{
    public interface ISessionService : IGenericService<Session>
    {
        Task<IDataResult<List<Session>>> GetAllSessionsOfMovieAsync(int id);
        Task<IResult> CheckSeat(int sessionId, int seatNumber);
    }
}
