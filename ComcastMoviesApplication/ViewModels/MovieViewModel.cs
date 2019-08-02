using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComcastMoviesApplication.ViewModels
{
    public class MovieViewModel
    {

        public Guid id { get; set; }

        public string title { get; set; }

        public int yearOfRelease { get; set; }

        public int runningTime { get; set; }

        public double averageRating { get; set; }
    }
}