using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Q2.Models;
using MVC_Q2.Repository;

namespace MVC_Q2.Controllers
{
    public class MoviesController : Controller
    {
        private IMovieRepository<Movies> _movieRepo = null;

        public MoviesController()
        {
            _movieRepo = new MovieRepository<Movies>();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movies movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepo.Insert(movie);
                _movieRepo.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _movieRepo.GetById(id);
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movies movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepo.Update(movie);
                _movieRepo.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
    }
}
