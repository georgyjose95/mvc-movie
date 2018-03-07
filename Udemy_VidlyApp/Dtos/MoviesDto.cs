using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Udemy_VidlyApp.Dtos
{
    public class MoviesDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Movie name required")]

        public string Name { get; set; }
       

        [Required(ErrorMessage = "Please specify the Release date!")]
        public DateTime ReleaseDate { get; set; }
        
        [Required(ErrorMessage = "Please specify the Date added!")]
        public DateTime DateAdded { get; set; }
        [Range(0, 20)]
        [Required(ErrorMessage = "The stock must be between 0 - 20")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Please select the Genre Type")]
        public int GenreId { get; set; }
    }
}