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
    public class TourTestimonialItemsController : Controller
    {
        private readonly TourifyDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TourTestimonialItemsController(TourifyDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context
                .TourTestimonialItems
                .AsNoTracking()
                .Include(x => x.TourItem)
                .ToListAsync();

            return View("~/Areas/Management/Views/TourTestimonialItems/Index.cshtml", model);
        }

        public async Task<IActionResult> Create()
        {
            var tourItems = await _context
                .TourItems
                .AsNoTracking()
                .ToListAsync();

            if (tourItems is null || tourItems.Count == 0)
                return RedirectToAction("Index", "TourItems");

            ViewData["TourItems"] = new SelectList(tourItems, "Id", "Title");

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TourTestimonialItem model, IFormFile? ProfileImage)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();
                model.ProfileImageUrl = await UploadProfileImageAsync(ProfileImage);

                await _context.TourTestimonialItems.AddAsync(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            var tourItems = await _context
                .TourItems
                .AsNoTracking()
                .ToListAsync();

            ViewData["TourItems"] = new SelectList(tourItems, "Id", "Title", model.TourItemId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context
                .TourTestimonialItems
                .Where(x => x.Id == id)
                .Include(x => x.TourItem)
                .FirstOrDefaultAsync();

            if (model is null)
                return Json(new { success = false, message = "Veri bulunamadı" });

            _context.TourTestimonialItems.Remove(model);
            await FileUploader.DeleteAsync(_env, model.ProfileImageUrl);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Veri silindi" });
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var model = await _context
                .TourTestimonialItems
                .Where(x => x.Id == id)
                .Include(x => x.TourItem)
                .FirstOrDefaultAsync();

            if (model is null)
                return RedirectToAction(nameof(Index));

            var tourItems = await _context
                .TourItems
                .AsNoTracking()
                .ToListAsync();

            ViewData["TourItems"] = new SelectList(tourItems, "Id", "Title", model.TourItemId);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TourTestimonialItem model, IFormFile? ProfileImage)
        {
            if (ModelState.IsValid)
            {
                var edited = await _context
                    .TourTestimonialItems
                    .Where(x => x.Id == model.Id)
                    .FirstOrDefaultAsync();

                if (edited is null)
                    return RedirectToAction(nameof(Index));

                edited.FullName = model.FullName;
                edited.Address = model.Address;
                edited.Description = model.Description;
                edited.TourItemId = model.TourItemId;

                var uploadedImagePath = await UploadProfileImageAsync(ProfileImage);
                if (!string.IsNullOrEmpty(uploadedImagePath))
                {
                    await FileUploader.DeleteAsync(_env, edited.ProfileImageUrl);
                    edited.ProfileImageUrl = uploadedImagePath;
                }

                _context.Entry(edited).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            var tourItems = await _context
                .TourItems
                .AsNoTracking()
                .ToListAsync();

            ViewData["TourItems"] = new SelectList(tourItems, "Id", "Title", model.TourItemId);

            return View(model);
        }

        private async Task<string?> UploadProfileImageAsync(IFormFile? profileImage)
        {
            if (profileImage is null)
                return null;

            Directory.CreateDirectory(Path.Combine(_env.WebRootPath, "uploads"));
            return await FileUploader.UploadAsync(_env, profileImage);
        }
    }
}
