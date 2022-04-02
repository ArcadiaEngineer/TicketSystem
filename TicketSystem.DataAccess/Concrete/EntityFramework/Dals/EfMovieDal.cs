using TicketSystem.Core.Abstract.Dal;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Dals
{
    public class EfMovieDal : EntityRepositoryBase<Movie, AppContext>, IMovieDal
    {
    }
}
