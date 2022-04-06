using TicketSystem.Core.Utilities.Results;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Abstract
{
    public interface IPaymentService : IGenericService<Payment>
    {
        Task<IDataResult<List<Payment>>> GetAllPaymentOfUser(int id);
    }
}
