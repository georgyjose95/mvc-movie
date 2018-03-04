using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Udemy_VidlyApp.Models
{
    public class Movie
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Movie name required")]
        
        public string Name { get; set; }
        [Display(Name=" Release Date")]
        [Required(ErrorMessage ="Please specify the Release date!")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        [Required(ErrorMessage = "Please specify the Date added!")]
        public DateTime DateAdded { get; set; }
        [Range(0,20)]
        [Required(ErrorMessage ="The stock must be between 0 - 20")]
        public int Stock { get; set; }
        
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        [Required(ErrorMessage ="Please select the Genre Type")]
        public int  GenreId { get; set; }
    }

   
}