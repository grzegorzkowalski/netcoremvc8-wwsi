using FilmDB.Models;
using FilmDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        private readonly FilmManager _manager;
        public FilmController(FilmManager manager) 
        { 
            _manager = manager;
        }
        public async Task<IActionResult> Index()
        {
            var filmList = await _manager.GetFilms();
            return View(filmList);
        }

        [HttpGet]
        public IActionResult Add() 
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(FilmModel film)
        {
            try
            {
                await _manager.AddFilm(film);
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {

                return View(film);
            }
        }
    }
}
