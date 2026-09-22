using KJ.Tourify.WebUI.Models;
using KJ.Tourify.WebUI.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KJ.Tourify.WebUI.Areas.Management.Controllers
{
    [Area("Management"), Authorize]
    public class GalleryCategoriesController : Controller
    {
        private readonly TourifyDbContext _context;

        public GalleryCategoriesController(TourifyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context
                .GalleryCategories
                .AsNoTracking()
                .Include(x => x.GalleryPage)
                .ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            var pages = await _context
                .GalleryPages
                .AsNoTracking()
                .ToListAsync();

            ViewData["Pages"] = new SelectList(pages, "Id", "GalleryTitle");

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GalleryCategory model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();

                await _context.GalleryCategories.AddAsync(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            var pages = await _context
                .GalleryPages
                .AsNoTracking()
                .ToListAsync();

            ViewData["Pages"] = new SelectList(pages, "Id", "GalleryTitle", model.GalleryPageId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var category = await _context
                .GalleryCategories
                .FindAsync(id);

            if (category is null)
                return Json(new { success = false, message = "Kategori bulunamadı!" });

            await _context
                .Entry(category)
                .Collection(x => x.GalleryItems)
                .LoadAsync();

            if (category.GalleryItems != null && category.GalleryItems.Count > 0)
                return Json(new { success = false, message = "Önce kategorinin gallery item ile ilişkisini silin!" });

            _context.GalleryCategories.Remove(category);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Kategori silindi." });
        }
    }
}