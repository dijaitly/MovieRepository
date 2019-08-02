using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComcastMovieApplicationDbModel;
using ComcastMovieApplicationDbModel.Models;
using ComcastMoviesApplication.Common;
using System.Data.Entity;

namespace ComcastMoviesApplication.Services
{
    public class MoviesService : IMoviesService
    {
        
        public IEnumerable<MovieRating> FindMovie(string title, string yearOfRelease, string genre)
        {
            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(yearOfRelease) && string.IsNullOrEmpty(genre)) throw new ArgumentNullException("Find Movie Argument is null");
            var context = new MoviesDbContext();
            var movieRatings = context.MovieRatings.Include(x => x.Movie) ;
            if (!string.IsNullOrEmpty(title)) {movieRatings= movieRatings.Where(x => x.Movie.Title.Contains(title)); }
            if(!string.IsNullOrEmpty(yearOfRelease))
            {
                int convertedYearOfRelease;
                if(int.TryParse(yearOfRelease,out convertedYearOfRelease))
                {
                   movieRatings=  movieRatings.Where(x => x.Movie.YearOfRelease == convertedYearOfRelease);
                }
            }

            if(!string.IsNullOrEmpty(genre))
            {
                movieRatings = movieRatings.Where(x => x.Movie.Genre == genre);
            }

            return movieRatings.ToList();
        }

        public IEnumerable<MovieRating> GetTopMoviesByRating()
        {
            var context = new MoviesDbContext();
            var movieIds= context.MovieRatings.GroupBy(x => x.MovieId).Select(g => new { name = g.Key, sum = g.Sum(x => x.Rating) }).OrderByDescending(x => x.sum).Take(5).Select(x=>x.name).ToList();
            var movieRatings = context.MovieRatings.Include(x=>x.Movie).Where(x => movieIds.Contains(x.Movie.Id));
            return movieRatings.ToList();

        }

        public IEnumerable<MovieRating> GetTopMoviesByUserRating(Guid userId)
        {
            var context = new MoviesDbContext();
            var movieIds = context.MovieRatings.Where(x=>x.UserId == userId).GroupBy(x => x.MovieId).Select(g => new { name = g.Key, sum = g.Sum(x => x.Rating) }).OrderByDescending(x => x.sum).Take(5).Select(x => x.name).ToList();
            var movieRatings = context.MovieRatings.Include(x=>x.Movie).Where(x => movieIds.Contains(x.Movie.Id));
            return movieRatings.ToList();
        }

        public void ModifyUserRatingForMovie(string userId, string movieId,string rating)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(movieId)) throw new ArgumentException("Parameters are null");
            Guid guidUserId;
            Guid guidMovieId;
            int intRating;
            if (!Guid.TryParse(userId, out guidUserId)) throw new ArgumentException("UserId not in correct format");
            if (!Guid.TryParse(movieId, out guidMovieId)) throw new ArgumentException("MovieId not in correct format");
            if (!int.TryParse(rating, out intRating)) throw new ArgumentException("Rating not in correct format");
            if (intRating < 1 || intRating > 5) throw new ArgumentException("Rating must be between 0 and 5");
            var context = new MoviesDbContext();
            var movieRating = context.MovieRatings.Where(x => x.UserId == guidUserId && x.MovieId == guidMovieId).SingleOrDefault();
            if(movieRating == null)
            {
              var newMovieCreatingRating=   context.MovieRatings.Create();
                newMovieCreatingRating.Id = Guid.NewGuid();
                newMovieCreatingRating.MovieId = guidMovieId;
                newMovieCreatingRating.UserId = guidUserId;
                newMovieCreatingRating.Rating = intRating;
                context.MovieRatings.Add(newMovieCreatingRating);
            }
            else
            {
                movieRating.Rating = intRating;

            }
            context.SaveChanges();

        }
    }
}