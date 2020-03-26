using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebbLab3
{
    public class SeedDatabaseModel : PageModel
    {
        private readonly WebbLab3.WebbLab3Context _context;
        public bool seedSuccesfull = false;
        public bool seedFailed = false;

        public SeedDatabaseModel(WebbLab3.WebbLab3Context context)
        {
            _context = context;
        }

        public void OnPostSeedDatabase()
        {
            if (!_context.Movie.Any()) 
            { 
                _context.SeedDatabase();
                seedSuccesfull = true;
            }
            else
            {
                seedFailed = true;
            }
        }

        public void OnPostEmptyDatabase()
        {
            foreach(var movie in _context.Movie)
            {
                _context.Movie.Remove(movie);
            }
            _context.SaveChanges();
        }
    }
}
