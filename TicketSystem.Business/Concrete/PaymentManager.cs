using TicketSystem.Business.Abstract;
using TicketSystem.Business.Utilities.ValidationRules;
using TicketSystem.Core.Aspects.Autofac;
using TicketSystem.Core.Utilities.Results;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        readonly IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        [ValidationAspect(typeof(PaymentValidationRules))]
        public async Task<IDataResult<Payment>> CreateAsync(Payment payment)
        {
            var addedEntity = await _paymentDal.CreateAsync(payment);
            if (addedEntity != null)
            {
                return new SuccessDataResult<Payment>(addedEntity);
            }
            return new ErrorDataResult<Payment>();
        }

        public async Task<IDataResult<List<Payment>>> GetAllAsync()
        {
            var list = await _paymentDal.GetAllAsync();
            if (list != null)
            {
                return new SuccessDataResult<List<Payment>>(list);
            }
            return new ErrorDataResult<List<Payment>>();
        }

        public async Task<IDataResult<Payment>> GetByIdAsync(int id)
        {
            var payment = await _paymentDal.GetByFilterAsync(p => p.PaymentId == id);
            if (payment != null)
            {
                return new SuccessDataResult<Payment>(payment);
            }
            return new ErrorDataResult<Payment>();
        }

        public async Task<IResult> RemoveAsync(Payment payment)
        {
            _paymentDal.Remove(payment);
            return await Task.FromResult(new SuccessResult());
        }

        [ValidationAspect(typeof(PaymentValidationRules))]
        public async Task<IDataResult<Payment>> UpdateAsync(Payment payment)
        {
            var updatedEntity = _paymentDal.Update(payment);

            return await Task.FromResult(new SuccessDataResult<Payment>(updatedEntity));
        }
    }
}
