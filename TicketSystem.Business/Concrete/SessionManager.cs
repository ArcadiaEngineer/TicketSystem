using TicketSystem.Business.Abstract;
using TicketSystem.Business.Utilities.ValidationRules;
using TicketSystem.Core.Aspects.Autofac;
using TicketSystem.Core.Utilities.Results;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Concrete
{
    public class SessionManager : ISessionService
    {
        readonly ISessionDal _seesionDal;

        public SessionManager(ISessionDal seesionDal)
        {
            _seesionDal = seesionDal;
        }

        [ValidationAspect(typeof(SessionValidationRules))]
        public async Task<IDataResult<Session>> CreateAsync(Session session)
        {
            var addedSession = await _seesionDal.CreateAsync(session);
            if (addedSession != null)
            {
                return new SuccessDataResult<Session>(addedSession);
            }
            return new ErrorDataResult<Session>();
        }

        public async Task<IDataResult<List<Session>>> GetAllAsync()
        {
            var list = await _seesionDal.GetAllAsync();
            if (list != null)
            {
                return new SuccessDataResult<List<Session>>(list);
            }
            return new ErrorDataResult<List<Session>>();
        }

        public async Task<IDataResult<Session>> GetByIdAsync(int id)
        {
            var session = await _seesionDal.GetByFilterAsync(s => s.SessionId == id);
            if (session != null)
            {
                return new SuccessDataResult<Session>(session);
            }
            return new ErrorDataResult<Session>();
        }

        public async Task<IResult> RemoveAsync(Session session)
        {
            _seesionDal.Remove(session);
            return await Task.FromResult(new SuccessResult());
        }

        [ValidationAspect(typeof(SessionValidationRules))]
        public async Task<IDataResult<Session>> UpdateAsync(Session session)
        {
            var updatedSession = _seesionDal.Update(session);
            return await Task.FromResult(new SuccessDataResult<Session>(updatedSession));
        }
    }
}
