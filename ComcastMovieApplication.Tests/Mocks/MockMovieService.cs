using ComcastMovieApplicationDbModel.Models;
using ComcastMoviesApplication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastMovieApplication.Tests.Mocks
{
    public class MockMovieService : IMoviesService
    {
        public IEnumerable<MovieRating> FindMovie(string title, string yearOfRelease, string genre)
        {
            List<MovieRating> movieRatings = new List<MovieRating>();
            MovieRating movieRating = new MovieRating();
            movieRating.Id = Guid.NewGuid();
            movieRating.MovieId = Guid.NewGuid();
            movieRating.Rating = 2;
            movieRating.UserId = Guid.NewGuid();
            movieRating.Movie = new Movie();
            movieRating.Movie.Id = movieRating.MovieId;
            movieRating.Movie.RunningTime = 90;
            movieRating.Movie.Title = "Lion King";
            movieRating.Movie.YearOfRelease = 1998;
            movieRating.Movie.Genre = "Animation";
            movieRatings.Add(movieRating);

            MovieRating movieRating1 = new MovieRating();
            movieRating1.Id = Guid.NewGuid();
            movieRating1.MovieId = Guid.NewGuid();
            movieRating1.Rating = 5;
            movieRating1.UserId = Guid.NewGuid();
            movieRating1.Movie = new Movie();
            movieRating1.Movie.Id = movieRating1.MovieId;
            movieRating1.Movie.RunningTime = 90;
            movieRating1.Movie.Title = "Harry Potter";
            movieRating1.Movie.YearOfRelease = 2001;
            movieRating1.Movie.Genre = "Children";
            movieRatings.Add(movieRating1);
            return movieRatings;
        }

        public IEnumerable<MovieRating> GetTopMoviesByRating()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieRating> GetTopMoviesByUserRating(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void ModifyUserRatingForMovie(string userId, string movieId, string rating)
        {
            throw new NotImplementedException();
        }
    }
}
