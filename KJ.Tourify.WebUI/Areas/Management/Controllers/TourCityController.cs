
using KJ.Tourify.WebUI.Models;
using KJ.Tourify.WebUI.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KJ.Tourify.WebUI.Areas.Management.Controllers
{
    [Area("Management"), Authorize]
    public class TourCitiesController : Controller
    {
        private readonly TourifyDbContext _context;

        public TourCitiesController(TourifyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context
                .TourCities
                .AsNoTracking()
                
                .ToListAsync());
            
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TourCity model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();

                await _context.TourCities.AddAsync(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var city = await _context
                .TourCities
                .FindAsync(id);

            if (city is null)
                return Json(new { success = false, message = "Şehir bulunamadı!" });

            await _context
                .Entry(city)
                .Collection(x => x.TourItems)
                .LoadAsync();

            if (city.TourItems != null && city.TourItems.Count > 0)
                return Json(new { success = false, message = "Önce şehrin tour ile ilişkisini silin!" });

            _context.TourCities.Remove(city);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Şehir silindi." });
        }
    }
}