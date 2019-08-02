namespace ComcastMovieApplicationDbModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ComcastMovieApplicationDbModel.MoviesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ComcastMovieApplicationDbModel.MoviesDbContext context)
        {
           
            
            if (!context.Movies.Any())
            {
                var movie = context.Movies.Create();
                movie.Id = Guid.NewGuid();
                movie.RunningTime = 90;
                movie.Title = "Lion King";
                movie.YearOfRelease = 1994;
                movie.Genre = "Animation";
                context.Movies.Add(movie);

                var movie1 = context.Movies.Create();
                movie1.Id = Guid.NewGuid();
                movie1.RunningTime = 120;
                movie1.Title = "Jurassic Park";
                movie1.YearOfRelease = 1998;
                movie1.Genre = "Science Fiction";
                context.Movies.Add(movie1);
                context.SaveChanges();
            }

            if(!context.Users.Any())
            {
                var user = context.Users.Create();
                user.Id = Guid.NewGuid();
                user.Name = "Paul Smith";
                context.Users.Add(user);
                var user1 = context.Users.Create();
                user1.Id = Guid.NewGuid();
                user1.Name = "Joe Martin";
                context.Users.Add(user1);
                var user2 = context.Users.Create();
                user2.Id = Guid.NewGuid();
                user2.Name = "James Rodriguez";
                context.Users.Add(user2);
                var user3 = context.Users.Create();
                user3.Id = Guid.NewGuid();
                user3.Name = "Liss Mathews";
                context.Users.Add(user3);
                context.SaveChanges();
            }
            if(!context.MovieRatings.Any())
            {
                var movie = context.Movies.Where(x => x.Title == "Lion King").FirstOrDefault();
                
                if(movie !=null)
                {
                    var user = context.Users.Where(x => x.Name == "Paul Smith").FirstOrDefault();
                    if(user !=null)
                    {
                       var movieRating=  context.MovieRatings.Create();
                        movieRating.Id = Guid.NewGuid();
                        movieRating.MovieId = movie.Id;
                        movieRating.UserId = user.Id;
                        movieRating.Rating = 3;
                        context.MovieRatings.Add(movieRating);
                    }
                    var user1 = context.Users.Where(x => x.Name == "Joe Martin").FirstOrDefault();
                    if (user1 != null)
                    {
                        var movieRating = context.MovieRatings.Create();
                        movieRating.Id = Guid.NewGuid();
                        movieRating.MovieId = movie.Id;
                        movieRating.UserId = user1.Id;
                        movieRating.Rating = 4;
                        context.MovieRatings.Add(movieRating);
                    }
                    var user2 = context.Users.Where(x => x.Name == "Liss Mathews").FirstOrDefault();
                    if (user2 != null)
                    {
                        var movieRating = context.MovieRatings.Create();
                        movieRating.Id = Guid.NewGuid();
                        movieRating.MovieId = movie.Id;
                        movieRating.UserId = user2.Id;
                        movieRating.Rating = 2;
                        context.MovieRatings.Add(movieRating);
                    }
                }


                var movie1 = context.Movies.Where(x => x.Title == "Jurassic Park").FirstOrDefault();

                if (movie1 != null)
                {
                    var user = context.Users.Where(x => x.Name == "Paul Smith").FirstOrDefault();
                    if (user != null)
                    {
                        var movieRating = context.MovieRatings.Create();
                        movieRating.Id = Guid.NewGuid();
                        movieRating.MovieId = movie1.Id;
                        movieRating.UserId = user.Id;
                        movieRating.Rating = 1;
                        context.MovieRatings.Add(movieRating);
                    }
                    var user1 = context.Users.Where(x => x.Name == "Joe Martin").FirstOrDefault();
                    if (user1 != null)
                    {
                        var movieRating = context.MovieRatings.Create();
                        movieRating.Id = Guid.NewGuid();
                        movieRating.MovieId = movie1.Id;
                        movieRating.UserId = user1.Id;
                        movieRating.Rating = 3;
                        context.MovieRatings.Add(movieRating);
                    }
                    var user2 = context.Users.Where(x => x.Name == "Liss Mathews").FirstOrDefault();
                    if (user2 != null)
                    {
                        var movieRating = context.MovieRatings.Create();
                        movieRating.Id = Guid.NewGuid();
                        movieRating.MovieId = movie1.Id;
                        movieRating.UserId = user2.Id;
                        movieRating.Rating = 5;
                        context.MovieRatings.Add(movieRating);
                    }
                }
                context.SaveChanges();
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
