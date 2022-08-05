using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required(ErrorMessage ="a title is required"), MaxLength(60), MinLength(2)]
        public string Title { get; set; }

        [Required(ErrorMessage ="a rating is required"),Range(0,10)]
        public int OverAllRating { get; set; }

        [MaxLength(30), MinLength(2)]
        public string Country { get; set; }

        [Required(ErrorMessage = "a production year is required")]
        [Display(Name ="Year")]
        public int ProductionYear { get; set; }

        [Required(ErrorMessage = "a genre is required")]
        public Genre Genere { get; set; }

        public int DirectorID { get; set; }

        public virtual Director DirectorId { get; set; }
    }
}