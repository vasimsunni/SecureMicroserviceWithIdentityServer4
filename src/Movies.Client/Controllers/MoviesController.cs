﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Client.ApiServices;
using Movies.Client.Models;

namespace Movies.Client.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieApiService _movieApiService;

        public MoviesController(IMovieApiService movieApiService)
        {
            _movieApiService = movieApiService;
        }


        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _movieApiService.GetMovies());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieApiService.GetMovie(id.Value);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,Rating,ReleaseDate,ImageUrl,Owner")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieApiService.CreateMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieApiService.GetMovie(id.Value);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Rating,ReleaseDate,ImageUrl,Owner")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _movieApiService.UpdateMovie(movie);
                }
                catch (Exception ex)
                {
                    var movieObj = await _movieApiService.GetMovie(id);
                    if (movieObj == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieApiService.GetMovie(id.Value);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _movieApiService.GetMovie(id);
            if (movie != null)
            {
                await _movieApiService.DeleteMovie(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
