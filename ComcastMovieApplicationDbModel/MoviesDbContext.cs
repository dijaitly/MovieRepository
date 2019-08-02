using ComcastMovieApplicationDbModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastMovieApplicationDbModel
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(): base("MoviesContext")
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieRating> MovieRatings { get; set; }
    }
}
