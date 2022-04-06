using Microsoft.EntityFrameworkCore;
using TicketSystem.Core.Abstract.Dal;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Dals
{
    public class EfPaymentDal : EntityRepositoryBase<Payment, AppContext>, IPaymentDal
    {
        public async Task<List<Payment>> GetAllPaymentOfUser(int id)
        {
            using (AppContext context = new())
            {
                return await context.Set<Payment>().Where(p => p.CustomerId == id).ToListAsync();
            }
        }
    }
}
