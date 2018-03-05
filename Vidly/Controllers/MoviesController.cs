using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;


namespace Vidly.Controllers
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
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer {Name="Customer 1" },
                new Customer {Name="Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movies = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int MovieId)
        {
            return Content("Id= " + MovieId);
        }

        public ActionResult Index(int? PageIndex, string SortBy)
        {
            #region test code
            //if (!PageIndex.HasValue)
            //    PageIndex = 1;
            //if (string.IsNullOrWhiteSpace(SortBy))
            //    SortBy = "Name";

            //return Content(String.Format("Page index= {0}&SortBy = {1}", PageIndex, SortBy));

            #endregion //commented

            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);


        }
        public ActionResult Details(int id)
        {
            var mov = _context.Movies.Include(c => c.Genre).Where(m => m.Id == id).SingleOrDefault();

            return View(mov);
        }



        [Route("movies/Released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}