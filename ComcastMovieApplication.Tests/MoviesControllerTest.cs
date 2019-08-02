using ComcastMoviesApplication.Common;
using ComcastMoviesApplication.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComcastMovieApplication.Tests
{
    [TestClass]
    public class MoviesControllerTest
    {
        [TestMethod]
        public void FindMoviesTest()
        {
            IMoviesService mockService = new Mocks.MockMovieService();
            MoviesController mController = new MoviesController(mockService);
            HttpResponseMessage responseMessage= mController.FindMovies("Lion", null, null);
            Assert.AreEqual(HttpStatusCode.OK, responseMessage.StatusCode);
            HttpResponseMessage responseMessage1 = mController.FindMovies("AbC", null, null);
            Assert.AreEqual(HttpStatusCode.OK, responseMessage.StatusCode);
            
        }

    }
}
