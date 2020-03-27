using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebbLab3
{
    public class WebbLab3Context : DbContext
    {
        public WebbLab3Context (DbContextOptions<WebbLab3Context> options)
            : base(options)
        {
        }

        public DbSet<WebbLab3.Movie> Movie { get; set; }

        public void SeedDatabase()
        {
            Movie[] seedMovies =
            {
                GenerateMovie("Coolboi: Unleashed", new DateTime(2020, 03, 24, 18, 30, 0), 1),
                GenerateMovie("BoiCool: Leashed", new DateTime(2020, 03, 24, 18, 30, 0), 2),
                GenerateMovie("Extreme Dude In Space", new DateTime(2020, 03, 24, 20, 30, 0), 1),
                GenerateMovie("Watch Out, I Have Gun!", new DateTime(2020, 03, 24, 15, 0, 0), 2)
            };

            foreach (var movie in seedMovies)
            {
                Movie.Add(movie);
            }

            this.SaveChanges();
        }
        Movie GenerateMovie(string title, DateTime startTime, int salon)
        {
            var newMovie = new Movie();
            newMovie.Title = title;
            newMovie.StartTime = startTime;
            newMovie.Salon = salon;
            if (salon == 1)
            {
                newMovie.SeatsLeft = 50;
                return newMovie;
            }
            else if (salon == 2)
            {
                newMovie.SeatsLeft = 100;
                return newMovie;
            }
            else
            {
                throw new Exception("Invalid salon");
            }
            
        }
    }
}
