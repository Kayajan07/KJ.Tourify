using KB.Utils;
using KJ.Tourify.WebUI.Models;
using KJ.Tourify.WebUI.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KJ.Tourify.WebUI.Areas.Management.Controllers
{
    [Area("Management"), Authorize]
    public class AboutPagesController : Controller
    {
        private readonly TourifyDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutPagesController(TourifyDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.AboutPages.FirstOrDefaultAsync();

            if (model is null)
            {
                model = new AboutPage
                {
                    Id = Guid.NewGuid()
                };

                await _context.AboutPages.AddAsync(model);
                await _context.SaveChangesAsync();
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var model = await _context.AboutPages.FirstOrDefaultAsync();

            if (model is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            AboutPage model, 
            IFormFile? 
            AboutImageUrl)
        {
            if (ModelState.IsValid)
            {
                if (AboutImageUrl != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.AboutImageUrl))
                        await FileUploader.DeleteAsync(_env, model.AboutImageUrl);

                    model.AboutImageUrl = await FileUploader.UploadAsync(_env, AboutImageUrl);
                }

                _context.AboutPages.Update(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}