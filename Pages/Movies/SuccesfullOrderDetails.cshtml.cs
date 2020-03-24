using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebbLab3
{
    public class SuccesfullOrderDetailsModel : PageModel
    {
        private readonly WebbLab3.WebbLab3Context _context;

        public SuccesfullOrderDetailsModel(WebbLab3.WebbLab3Context context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }
        
        public int TicketsPurchased { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int ticketsPurchased)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);
            TicketsPurchased = ticketsPurchased;

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
