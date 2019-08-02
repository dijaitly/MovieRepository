using ComcastMovieApplicationDbModel.Models;
using ComcastMoviesApplication.Common;
using ComcastMoviesApplication.Helpers;
using ComcastMoviesApplication.Services;
using ComcastMoviesApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ComcastMoviesApplication.Controllers
{
    public class MoviesController : ApiController
    {
        private IMoviesService movieService;
        public MoviesController()
        {
            movieService = new MoviesService();
        }

        public MoviesController(IMoviesService service)
        {
            movieService = service;
        }


        [Route("MovieApi/FindMovies")]
        [HttpGet] 
        public HttpResponseMessage FindMovies(string title=null, string yearOfRelease=null, string genre=null)        
        {
            
            
            try
            {
                ComcastMoviesApplication.Helpers.ValidationHelper vHelper = new ComcastMoviesApplication.Helpers.ValidationHelper();
                if (!vHelper.IsValidFindMovieRequest(title, yearOfRelease, genre))
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

                IEnumerable<MovieRating> movieRatings = movieService.FindMovie(title, yearOfRelease, genre);
                IEnumerable<MovieViewModel> movieViewModels = new AggregateHelper().Aggregate(movieRatings);
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                responseMessage.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(movieViewModels));
                return responseMessage;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }


        [Route("MovieApi/GetTopMoviesByRating")]
        [HttpGet]
        public HttpResponseMessage GetTopMoviesByRating()
        {
            try
            {

                IEnumerable<MovieRating> movieRatings = movieService.GetTopMoviesByRating();
                IEnumerable<MovieViewModel> movieViewModels = new AggregateHelper().Aggregate(movieRatings);
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                responseMessage.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(movieViewModels));
                return responseMessage;

            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]

        [Route("MovieApi/GetTopMoviesByUserRating")]
        public HttpResponseMessage GetTopMoviesByUserRating(string userId=null)
        {
            try
            {
                ComcastMoviesApplication.Helpers.ValidationHelper vHelper = new ComcastMoviesApplication.Helpers.ValidationHelper();
                Guid? guid;
                if (!vHelper.IsValidGuid(userId, out guid))
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                if (!guid.HasValue) throw new ArgumentNullException("Guid is null");
                var movieRatings = movieService.GetTopMoviesByUserRating(guid.Value);
                IEnumerable<MovieViewModel> movieViewModels = new AggregateHelper().Aggregate(movieRatings);
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                responseMessage.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(movieViewModels));
                return responseMessage;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }


        [HttpPut]
        [Route("MovieApi/EditRating")]
        public HttpResponseMessage EditRating( [FromBody]string value, string userId = null, string movieId = null)
        {
            try
            {
                ComcastMoviesApplication.Helpers.ValidationHelper vHelper = new ComcastMoviesApplication.Helpers.ValidationHelper();
                if (!vHelper.IsValidEditMovieRatingRequest(userId, movieId, value))
                {
                    throw new ArgumentException("Parameters are null");
                }

                movieService.ModifyUserRatingForMovie(userId, movieId, value);
                return new HttpResponseMessage(HttpStatusCode.OK);

            }
            catch (ArgumentException aex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
    }
}
