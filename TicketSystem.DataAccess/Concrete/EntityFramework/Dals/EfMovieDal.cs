﻿using TicketSystem.Core.Abstract.Dal;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.Dtos.MovieDtos;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Dals
{
    public class EfMovieDal : EntityRepositoryBase<Movie, AppContext>, IMovieDal
    {
        
        MovieDetailDto IMovieDal.GetMovieDetail(int id)
        {
            using (AppContext context = new AppContext())
            {
                var result = from m in context.Movies
                             join c in context.Categories
                             on m.MovieCategoryId equals c.CategoryId
                             where m.MovieId == id
                             select new MovieDetailDto
                             {
                                 MovieName = m.MovieName,
                                 CategoryName = c.CategoryName,
                                 MovieId = m.MovieId,
                                 MovieBanner = m.MovieBanner,
                                 MovieVisionDate = m.MovieVisionDate,
                                 MovieAgeLimit = m.MovieAgeLimit,
                                 MovieReview = m.MovieReview
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
