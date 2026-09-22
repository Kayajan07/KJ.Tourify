using KB.Utils;
using KJ.Tourify.WebUI.Models;
using KJ.Tourify.WebUI.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KJ.Tourify.WebUI.Areas.Management.Controllers
{
    [Area("Management"), Authorize]
    public class GuidesPagesController : Controller
    {
        private readonly TourifyDbContext _context;
        private readonly IWebHostEnvironment _env;

        public GuidesPagesController(TourifyDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.GuidePages.FirstOrDefaultAsync();

            if (model is null)
            {
                model = new GuidePage
                {
                    Id = Guid.NewGuid(),
                };

                await _context.GuidePages.AddAsync(model);
                await _context.SaveChangesAsync();
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var model = await _context.GuidePages.FirstOrDefaultAsync();

            if (model is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            GuidePage model,
            IFormFile? GuideImageUrl1,
            IFormFile? GuideImageUrl2,
            IFormFile? GuideImageUrl3,
            IFormFile? GuideImageUrl4)
        {
            if (ModelState.IsValid)
            {
                if (GuideImageUrl1 != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.GuideImageUrl1))
                        await FileUploader.DeleteAsync(_env, model.GuideImageUrl1);

                    model.GuideImageUrl1 = await FileUploader.UploadAsync(_env, GuideImageUrl1);
                }

                if (GuideImageUrl2 != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.GuideImageUrl2))
                        await FileUploader.DeleteAsync(_env, model.GuideImageUrl2);

                    model.GuideImageUrl2 = await FileUploader.UploadAsync(_env, GuideImageUrl2);
                }

                if (GuideImageUrl3 != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.GuideImageUrl3))
                        await FileUploader.DeleteAsync(_env, model.GuideImageUrl3);

                    model.GuideImageUrl3 = await FileUploader.UploadAsync(_env, GuideImageUrl3);
                }

                if (GuideImageUrl4 != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.GuideImageUrl4))
                        await FileUploader.DeleteAsync(_env, model.GuideImageUrl4);

                    model.GuideImageUrl4 = await FileUploader.UploadAsync(_env, GuideImageUrl4);
                }

                _context.GuidePages.Update(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}