using System;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Lab5Cuong.Data;
using Lab5Cuong.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab5Cuong.Controllers
{
    public class MoviesController : Controller
    {
        private readonly Lab5CuongContext _context;

        public MoviesController(Lab5CuongContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .Include(m => m.Genres)  // Include the related Genres
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }


        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewBag.Genres = GetGenres();
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,ReleaseDate,Price,Rating,ProducerId")] Movie movie, int[] selectedGenres)
        {
            if (ModelState.IsValid)
            {
                if (movie.Genres == null)
                {
                    movie.Genres = new List<Genre>();
                }
                _context.Genres.Where(g => selectedGenres.Contains(g.Id)).ToList().ForEach(g => movie.Genres.Add(g));
                movie.Members = movie.Members.DistinctBy(x => new { x.Role, x.PersonId }).ToList();
                _context.Add(movie);


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProducerId"] = new SelectList(_context.Set<Company>(), nameof(Company.Id),nameof(Company.Name), movie.ProducerId);
            ViewData["People"] = await _context.Persons.ToListAsync();
            ViewBag.Genres = GetGenres();
            return View(movie);
        }


        private List<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .Include(m => m.Genres)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            ViewBag.Genres = await _context.Genres.ToListAsync();
            ViewBag.SelectedGenres = movie.Genres.Select(g => g.Id).ToList();

            return View(movie);
        }


        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Price,Rating,ProducerId")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var selectedGenres = Request.Form["selectedGenres"].Select(g => int.Parse(g)).ToList();

                try
                {
                    // Retrieve the existing movie from the database including its genres
                    var movieToUpdate = await _context.Movie
                        .Include(m => m.Genres)
                        .FirstOrDefaultAsync(m => m.Id == id);

                    if (movieToUpdate == null)
                    {
                        return NotFound();
                    }

                    // Update scalar properties
                    movieToUpdate.Title = movie.Title;
                    movieToUpdate.ReleaseDate = movie.ReleaseDate;
                    movieToUpdate.Price = movie.Price;
                    movieToUpdate.Rating = movie.Rating;
                    movieToUpdate.ProducerId = movie.ProducerId;

                    // Clear the existing genres
                    movieToUpdate.Genres.Clear();

                    // Add the new selected genres
                    var newGenres = await _context.Genres.Where(g => selectedGenres.Contains(g.Id)).ToListAsync();
                    foreach (var genre in newGenres)
                    {
                        movieToUpdate.Genres.Add(genre);
                    }

                    // Update the movie entity
                    _context.Update(movieToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
