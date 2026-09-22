using KJ.Tourify.WebUI.Models;
using KJ.Tourify.WebUI.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KJ.Tourify.WebUI.Areas.Management.Controllers
{
    [Area("Management"), Authorize]
    public class GalleryPagesController : Controller
    {
        private readonly TourifyDbContext _context;

        public GalleryPagesController(TourifyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context
                .GalleryPages
                .FirstOrDefaultAsync();

            if (model is null)
            {
                model = new GalleryPage
                {
                    Id = Guid.NewGuid()
                };

                await _context.GalleryPages.AddAsync(model);
                await _context.SaveChangesAsync();
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var model = await _context
                .GalleryPages
                .FirstOrDefaultAsync();

            if (model is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GalleryPage model)
        {
            if (ModelState.IsValid)
            {
                _context.GalleryPages.Update(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GalleryPage model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();

                await _context.GalleryPages.AddAsync(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var page = await _context
                .GalleryPages
                .FindAsync(id);

            if (page is null)
                return Json(new { success = false, message = "Sayfa bulunamadı!" });

            await _context
                .Entry(page)
                .Collection(x => x.GalleryItems)
                .LoadAsync();

            if (page.GalleryItems != null && page.GalleryItems.Count > 0)
                return Json(new { success = false, message = "Önce sayfanın gallery item ile ilişkisini silin!" });

            await _context
                .Entry(page)
                .Collection(x => x.GalleryCategories)
                .LoadAsync();

            if (page.GalleryCategories != null && page.GalleryCategories.Count > 0)
                return Json(new { success = false, message = "Önce sayfanın kategori ile ilişkisini silin!" });

            _context.GalleryPages.Remove(page);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Sayfa silindi." });
        }
    }
}
