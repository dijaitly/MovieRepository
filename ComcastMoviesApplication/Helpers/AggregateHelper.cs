using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComcastMovieApplicationDbModel;
using ComcastMovieApplicationDbModel.Models;
using ComcastMoviesApplication.ViewModels;

namespace ComcastMoviesApplication.Helpers
{
    public class AggregateHelper
    {
        public IEnumerable<MovieViewModel> Aggregate(IEnumerable<MovieRating> ratings)
        {
            var tempVariable = ratings.GroupBy(p => p.MovieId, p => p.Rating, (key, g) => new { MovieId = key, Avg = g.Average() });
            List<MovieViewModel> movieViewModels = new List<MovieViewModel>();
            foreach(var k in tempVariable)
            {
                var movie = ratings.Where(x => x.Movie.Id == k.MovieId).Select(x=>x.Movie).First();
                var viewModelEntity= new MovieViewModel { id = movie.Id, title = movie.Title, yearOfRelease = movie.YearOfRelease, runningTime = movie.RunningTime, averageRating = RoundingHelper.Round(k.Avg) };
                movieViewModels.Add(viewModelEntity);
            }
            return movieViewModels;
        }
    }
}