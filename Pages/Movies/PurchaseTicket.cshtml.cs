using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebbLab3
{
    public class PurchaseTicketModel : PageModel
    {
        private readonly WebbLab3.WebbLab3Context _context;

        public PurchaseTicketModel(WebbLab3.WebbLab3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        [BindProperty]
        public int TicketAmount { get; set; }
        public int ticketOptionAmount { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }

            if (Movie.SeatsLeft >= 12) { ticketOptionAmount = 12; }
            else { ticketOptionAmount = Movie.SeatsLeft; }

            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                RemoveSeatsByTicketAmount();
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(Movie.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./SuccesfullOrderDetails", new { id = Movie.ID, ticketsPurchased = TicketAmount });
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }

        private void RemoveSeatsByTicketAmount()
        {
            var movie = _context.Movie.First(movie => movie.ID == Movie.ID);
            if (movie.SeatsLeft - TicketAmount < 0) { throw new Exception("Not enough seats available"); }
            _context.Database.ExecuteSqlCommand("UPDATE dbo.Movie SET SeatsLeft = SeatsLeft - " + TicketAmount + " WHERE ID = " + Movie.ID);
        }
    }
}
