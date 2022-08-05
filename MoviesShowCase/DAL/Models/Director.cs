using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Director
    {
        [Key]
       
        public int DirectorId { get; set; }

        [Required(ErrorMessage = "a Full Name is required"), MaxLength(20), MinLength(2)]
        [Display(Name = "First Name")]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}