using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Udemy_VidlyApp.Models;

namespace Udemy_VidlyApp.ViewModel
{
    public class MoviesFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}