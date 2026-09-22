using KB.Utils;
using KJ.Tourify.WebUI.Models;
using KJ.Tourify.WebUI.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KJ.Tourify.WebUI.Areas.Management.Controllers
{
    [Area("Management"), Authorize]
    public class GalleryItemsController : Controller
    {
        private readonly TourifyDbContext _context;
        private readonly IWebHostEnvironment _env;

        public GalleryItemsController(TourifyDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context
                .GalleryItems
                .AsNoTracking()
                .Include(x => x.GalleryCategory)
                .Include(x => x.GalleryPage)
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            var model = await _context
                .GalleryItems
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.GalleryCategory)
                .Include(x => x.GalleryPage)
                .FirstOrDefaultAsync();

            if (model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _context
                .GalleryCategories
                .ToListAsync();

            if (categories is null)
                return RedirectToAction("Index", "GalleryCategories");

            ViewData["Categories"] = new SelectList(categories, "Id", "Name");

            var pages = await _context
                .GalleryPages
                .ToListAsync();

            ViewData["Pages"] = new SelectList(pages, "Id", "GalleryTitle");

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GalleryItem model, IFormFile? GalleryImage)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();
                model.GalleryImageUrl = await UploadGalleryImageAsync(GalleryImage);

                await _context.GalleryItems.AddAsync(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            var categories = await _context
                .GalleryCategories
                .ToListAsync();

            ViewData["Categories"] = new SelectList(categories, "Id", "Name", model.GalleryCategoryId);

            var pages = await _context
                .GalleryPages
                .ToListAsync();

            ViewData["Pages"] = new SelectList(pages, "Id", "GalleryTitle", model.GalleryPageId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context
                .GalleryItems
                .Where(x => x.Id == id)
                .Include(x => x.GalleryCategory)
                .Include(x => x.GalleryPage)
                .FirstOrDefaultAsync();

            if (model is null)
                return Json(new { success = false, message = "Veri bulunamadi" });

            _context.GalleryItems.Remove(model);
            await FileUploader.DeleteAsync(_env, model.GalleryImageUrl);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Veri silindi" });
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var model = await _context
                .GalleryItems
                .Where(x => x.Id == id)
                .Include(x => x.GalleryCategory)
                .Include(x => x.GalleryPage)
                .FirstOrDefaultAsync();

            if (model is null)
                return RedirectToAction(nameof(Index));

            var categories = await _context
                .GalleryCategories
                .AsNoTracking()
                .ToListAsync();

            ViewData["Categories"] = new SelectList(categories, "Id", "Name", model.GalleryCategoryId);

            var pages = await _context
                .GalleryPages
                .AsNoTracking()
                .ToListAsync();

            ViewData["Pages"] = new SelectList(pages, "Id", "GalleryTitle", model.GalleryPageId);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(GalleryItem model, IFormFile? GalleryImage)
        {
            if (ModelState.IsValid)
            {
                var edited = await _context
                    .GalleryItems
                    .Where(x => x.Id == model.Id)
                    .Include(x => x.GalleryCategory)
                    .Include(x => x.GalleryPage)
                    .FirstOrDefaultAsync();

                if (edited is null)
                    return RedirectToAction(nameof(Index));

                edited.Title = model.Title;
                var uploadedImagePath = await UploadGalleryImageAsync(GalleryImage);
                if (!string.IsNullOrEmpty(uploadedImagePath))
                {
                    await FileUploader.DeleteAsync(_env, edited.GalleryImageUrl);
                    edited.GalleryImageUrl = uploadedImagePath;
                }
                edited.GalleryCategoryId = model.GalleryCategoryId;
                edited.GalleryPageId = model.GalleryPageId;

                _context.Entry(edited).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            var categories = await _context
                .GalleryCategories
                .AsNoTracking()
                .ToListAsync();

            ViewData["Categories"] = new SelectList(categories, "Id", "Name", model.GalleryCategoryId);

            var pages = await _context
                .GalleryPages
                .AsNoTracking()
                .ToListAsync();

            ViewData["Pages"] = new SelectList(pages, "Id", "GalleryTitle", model.GalleryPageId);

            return View(model);
        }

        private async Task<string?> UploadGalleryImageAsync(IFormFile? galleryImage)
        {
            if (galleryImage is null || galleryImage.Length == 0)
                return null;

            Directory.CreateDirectory(Path.Combine(_env.WebRootPath, "uploads"));
            return await FileUploader.UploadAsync(_env, galleryImage);
        }
    }
}
