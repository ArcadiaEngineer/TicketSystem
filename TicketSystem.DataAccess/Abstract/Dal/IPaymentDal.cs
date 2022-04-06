using TicketSystem.Core.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Abstract.Dal
{
    public interface IPaymentDal : IRepositoryDal<Payment>
    {
        Task<List<Payment>> GetAllPaymentOfUser(int id);
    }
}
