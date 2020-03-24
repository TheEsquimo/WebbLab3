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
            if (!Movie.Any()) { SeedDatabase(); }
        }

        public DbSet<WebbLab3.Movie> Movie { get; set; }

        private void SeedDatabase()
        {
            Movie[] seedMovies =
            {
                new Movie
                {
                    Title = "Coolboi: Unleashed",
                    StartTime = new DateTime(2020, 03, 24, 18, 30, 0),
                    SeatsLeft = 50,
                    Salon = 1
                }
            };

            foreach (var movie in seedMovies)
            {
                Movie.Add(movie);
            }

            this.SaveChanges();
        }
    }
}
