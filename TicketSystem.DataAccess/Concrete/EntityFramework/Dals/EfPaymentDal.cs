using TicketSystem.Core.Abstract.Dal;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Dals
{
    public class EfPaymentDal : EntityRepositoryBase<Payment, AppContext>, IPaymentDal
    {
    }
}
