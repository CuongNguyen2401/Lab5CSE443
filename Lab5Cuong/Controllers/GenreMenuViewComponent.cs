using Lab5Cuong.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab5Cuong.Controllers
{
    public class GenreMenuViewComponent : ViewComponent
    {
        private readonly Lab5CuongContext _context;

        public GenreMenuViewComponent(Lab5CuongContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres = await _context.Genres.ToListAsync();
            return View(genres);
        }
    }
}
