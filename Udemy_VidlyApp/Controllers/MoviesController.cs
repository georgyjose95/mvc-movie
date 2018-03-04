using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy_VidlyApp.Models;
using Udemy_VidlyApp.ViewModel;
using System.Data.Entity;

namespace Udemy_VidlyApp.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        [Route("movies")]
        public ActionResult Movies()
        {

            var randommovieviewmodel = new RandomMovieViewModel
            {
                Movie = _context.Movie.Include(m=>m.Genre).ToList()

            };
            return View(randommovieviewmodel);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movie.Include(m => m.Genre).ToList().SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            ViewData["Movie"] = movie;
            return View();

        }

        public ActionResult NewMovie()
        {
            var movieviewModel = new MoviesFormViewModel {
                Movie = new Movie(),
                Genres = _context.Genres.ToList()
            };
            ViewBag.ViewModel = movieviewModel;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieviewmodel = new MoviesFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                ViewBag.ViewModel = movieviewmodel;
                return View("NewMovie");

            }
            _context.Movie.Add(movie);

            _context.SaveChanges();

            return RedirectToAction("Movies", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movie.Include(m => m.Genre).ToList().SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var movieviewModel = new MoviesFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            ViewBag.ViewModel = movieviewModel;
            return View();
        }
        [HttpPost]
        public ActionResult Update(Movie movie)
        {
            var movieinDb = _context.Movie.Include(m => m.Genre).ToList().SingleOrDefault(m => m.Id == movie.Id);

            movieinDb.Name = movie.Name;
            movieinDb.ReleaseDate = movie.ReleaseDate;
            movieinDb.DateAdded = movie.DateAdded;
            movieinDb.GenreId = movie.GenreId;
            movieinDb.Stock = movie.Stock;

            _context.SaveChanges();
            return RedirectToAction("Movies", "Movies");
        }

















            //ViewBag.Movie = movie;
            //ViewData["Movie"] = movie;


            //return Content("Leonardo Di Caprio");
            // return HttpNotFound();
            //  return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        

        //public ActionResult Edit(int id)
        //{ 
        //    return Content("id =" + id);
        //}

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (
        //        String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex ={0} &sortBy= {1}", pageIndex, sortBy));

            
        //}
        //[Route("movies/released/{year}/{month regex:(//d{2} : range(1,12)")] 
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year +"/"  + month);

        //}
        
        

    }
}