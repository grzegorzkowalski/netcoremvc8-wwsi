﻿using FilmDB.Models;
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

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            var filmToDelete = await _manager.GetFilm(id);
            return View(filmToDelete);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveConfirm(int id)
        {
            await _manager.RemoveFilm(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var filmToEdit = await _manager.GetFilm(id);
            return View(filmToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FilmModel film)
        {
            await _manager.UpdateFilm(film);
            return RedirectToAction("Index");
        }
    }
}
