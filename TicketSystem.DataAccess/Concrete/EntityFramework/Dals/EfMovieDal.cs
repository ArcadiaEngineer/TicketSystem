using TicketSystem.Core.Abstract.Dal;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.Dtos.MovieDtos;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Dals
{
    public class EfMovieDal : EntityRepositoryBase<Movie, AppContext>, IMovieDal
    {
        
        List<MovieDetailDto> IMovieDal.GetMovieDetails()
        {
            using (AppContext context = new AppContext())
            {
                var result = from m in context.Movies
                             join c in context.Categories
                             on m.MovieCategoryId equals c.CategoryId
                             select new MovieDetailDto
                             {
                                 MovieName = m.MovieName,
                                 CategoryName = c.CategoryName,
                                 MovieId = m.MovieId,
                                 MovieVisionDate = m.MovieVisionDate,
                                 MovieReleaseTime = m.MovieReleaseTime,
                                 MovieAgeLimit = m.MovieAgeLimit,
                                 MovieReview = m.MovieReview
                             };
                return result.ToList();
            }
        }
    }
}
