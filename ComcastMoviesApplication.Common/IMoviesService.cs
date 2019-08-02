using ComcastMovieApplicationDbModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastMoviesApplication.Common
{
    public interface IMoviesService
    {
        IEnumerable<MovieRating> FindMovie(string title, string yearOfRelease, string genre);

        IEnumerable<MovieRating> GetTopMoviesByRating();

        IEnumerable<MovieRating> GetTopMoviesByUserRating(Guid userId);

        void ModifyUserRatingForMovie(string userId, string movieId,string rating);

    }
}
