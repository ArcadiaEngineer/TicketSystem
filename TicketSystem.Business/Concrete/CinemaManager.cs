using TicketSystem.Business.Abstract;
using TicketSystem.Business.Utilities.ValidationRules;
using TicketSystem.Core.Aspects.Autofac;
using TicketSystem.Core.Utilities.Results;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Concrete
{
    public class CinemaManager : ICinemaService
    {
        readonly ICinemaDal _cinemaDal;
        public CinemaManager(ICinemaDal cinemaDal)
        {
            _cinemaDal = cinemaDal;
        }
        [ValidationAspect(typeof(CinemaValidationRules))]
        public async Task<IDataResult<Cinema>> CreateAsync(Cinema cinema)
        {
            var addedCinema = await _cinemaDal.CreateAsync(cinema);
            if (addedCinema != null)
            {
                return new SuccessDataResult<Cinema>(addedCinema);
            }
            return new ErrorDataResult<Cinema>();
        }

        public async Task<IDataResult<List<Cinema>>> GetAllAsync()
        {
            var list = await _cinemaDal.GetAllAsync();
            if (list != null)
            {
                return new SuccessDataResult<List<Cinema>>(list);
            }
            return new ErrorDataResult<List<Cinema>>();
        }

        public async Task<IDataResult<Cinema>> GetByIdAsync(int id)
        {
            var cinema = await _cinemaDal.GetByFilterAsync(c => c.CinemaId == id);
            if (cinema != null)
            {
                return new SuccessDataResult<Cinema>(cinema);
            }
            return new ErrorDataResult<Cinema>();
        }

        public async Task<IResult> RemoveAsync(Cinema cinema)
        {
            _cinemaDal.Remove(cinema);
            return await Task.FromResult(new SuccessResult());
        }

        [ValidationAspect(typeof(CinemaValidationRules))]
        public async Task<IDataResult<Cinema>> UpdateAsync(Cinema cinema)
        {
            var updatedCinema = _cinemaDal.Update(cinema);
            return await Task.FromResult(new SuccessDataResult<Cinema>(updatedCinema));
        }
    }
}
