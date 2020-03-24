using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebbLab3
{
    public class Movie
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public DateTime StartTime  { get; set; }

        [Required]
        [Range(0, 100)]
        [Display(Name = "Seats Available")]
        public int SeatsLeft { get; set; }

        [Required]
        [Range(1, 2)]
        public int Salon { get; set; }
    }
}
