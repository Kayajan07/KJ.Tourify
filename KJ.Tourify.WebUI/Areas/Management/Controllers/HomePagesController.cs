using KB.Utils;
using KJ.Tourify.WebUI.Models;
using KJ.Tourify.WebUI.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KJ.Tourify.WebUI.Areas.Management.Controllers
{

    [Area("Management"), Authorize]
    public class HomePagesController : Controller
    {

        private readonly TourifyDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HomePagesController(TourifyDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.HomePages.FirstOrDefaultAsync();
            if (model is null)
            {
                model = new HomePage
                {
                    Id = Guid.NewGuid(),
                };
                await _context.HomePages.AddAsync(model);
                await _context.SaveChangesAsync();



                
            }
            return View(model);
        }
        public async Task<IActionResult> Edit()
        {
            var model = await _context.HomePages.FirstOrDefaultAsync();
            if (model is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            HomePage model,
            IFormFile? ImageUrl1,
            IFormFile? ImageUrl2,
            IFormFile? ImageUrl3,
            IFormFile? HomeAboutImageUrl)
        {


            if (ModelState.IsValid)
            {
                if (ImageUrl1 != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.ImageUrl1))
                        await FileUploader.DeleteAsync(_env, model.ImageUrl1);

                    model.ImageUrl1 = await FileUploader.UploadAsync(_env, ImageUrl1);
                }

                if (ImageUrl2 != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.ImageUrl2))
                        await FileUploader.DeleteAsync(_env, model.ImageUrl2);

                    model.ImageUrl2 = await FileUploader.UploadAsync(_env, ImageUrl2);
                }

                if (ImageUrl3 != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.ImageUrl3))
                        await FileUploader.DeleteAsync(_env, model.ImageUrl3);

                    model.ImageUrl3 = await FileUploader.UploadAsync(_env, ImageUrl3);
                }
                if (HomeAboutImageUrl != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.HomeAboutImageUrl))
                        await FileUploader.DeleteAsync(_env, model.HomeAboutImageUrl);

                    model.HomeAboutImageUrl = await FileUploader.UploadAsync(_env, HomeAboutImageUrl);
                }



                _context.HomePages.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}

