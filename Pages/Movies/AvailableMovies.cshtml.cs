﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebbLab3
{
    public class AvailableMoviesModel : PageModel
    {
        private readonly WebbLab3.WebbLab3Context _context;

        public AvailableMoviesModel(WebbLab3.WebbLab3Context context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.OrderByDescending(movie => movie.SeatsLeft).ThenBy(movie => movie.Title).ToListAsync();
        }

        public void OnPostSeedDatabase()
        {
            _context.SeedDatabase();
        }

        public async Task OnPostSortBySeatsLeft()
        {
            Movie = await _context.Movie.OrderByDescending(movie => movie.SeatsLeft).ToListAsync();
        }

        public async Task OnPostSortByStartTime()
        {
            Movie = await _context.Movie.OrderByDescending(movie => movie.StartTime).ToListAsync();
        }
    }
}
