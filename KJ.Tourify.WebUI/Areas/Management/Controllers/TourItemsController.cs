using KJ.Tourify.WebUI.Models;
using KJ.Tourify.WebUI.Models.Entities;
using KB.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KJ.Tourify.WebUI.Areas.Management.Controllers
{
    [Area("Management"), Authorize]
    public class TourItemsController : Controller
    {
        private readonly TourifyDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TourItemsController(TourifyDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context
                .TourItems
                .AsNoTracking()
                .Include(x => x.City)
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            var model = await _context
                .TourItems
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.City)
                .Include(x => x.TourTestimonialItems)
                .FirstOrDefaultAsync();

            if (model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var cities = await _context
                .TourCities
                .AsNoTracking()
                .ToListAsync();

            if (cities is null || cities.Count == 0)
                return RedirectToAction("Index", "TourCities");

            ViewData["Cities"] = new SelectList(cities, "Id", "Name");

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TourItem model, IFormFile? TourImage)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();
                model.TourImageUrl = await UploadTourImageAsync(TourImage);

                await _context.TourItems.AddAsync(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            var cities = await _context
                .TourCities
                .AsNoTracking()
                .ToListAsync();

            ViewData["Cities"] = new SelectList(cities, "Id", "Name", model.TourCityId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context
                .TourItems
                .Where(x => x.Id == id)
                .Include(x => x.City)
                .FirstOrDefaultAsync();

            if (model is null)
                return Json(new { success = false, message = "Veri bulunamadı" });

            _context.TourItems.Remove(model);
            await FileUploader.DeleteAsync(_env, model.TourImageUrl);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Veri silindi" });
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var model = await _context
                .TourItems
                .Where(x => x.Id == id)
                .Include(x => x.City)
                .FirstOrDefaultAsync();

            if (model is null)
                return RedirectToAction(nameof(Index));

            var cities = await _context
                .TourCities
                .AsNoTracking()
                .ToListAsync();

            ViewData["Cities"] = new SelectList(cities, "Id", "Name", model.TourCityId);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TourItem model, IFormFile? TourImage)
        {
            if (ModelState.IsValid)
            {
                var edited = await _context
                    .TourItems
                    .Where(x => x.Id == model.Id)
                    .FirstOrDefaultAsync();

                if (edited is null)
                    return RedirectToAction(nameof(Index));

                edited.HowMuchMoney = model.HowMuchMoney;
                edited.Title = model.Title;
                edited.Description = model.Description;
                var uploadedImagePath = await UploadTourImageAsync(TourImage);
                if (!string.IsNullOrEmpty(uploadedImagePath))
                {
                    await FileUploader.DeleteAsync(_env, edited.TourImageUrl);
                    edited.TourImageUrl = uploadedImagePath;
                }
                edited.TourLocation = model.TourLocation;
                edited.TourDay = model.TourDay;
                edited.TourPerson = model.TourPerson;
                edited.TourCityId = model.TourCityId;

                _context.Entry(edited).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            var cities = await _context
                .TourCities
                .AsNoTracking()
                .ToListAsync();

            ViewData["Cities"] = new SelectList(cities, "Id", "Name", model.TourCityId);

            return View(model);
        }

        private async Task<string?> UploadTourImageAsync(IFormFile? tourImage)
        {
            if (tourImage is null || tourImage.Length == 0)
                return null;

            Directory.CreateDirectory(Path.Combine(_env.WebRootPath, "uploads"));
            return await FileUploader.UploadAsync(_env, tourImage);
        }
    }
}
