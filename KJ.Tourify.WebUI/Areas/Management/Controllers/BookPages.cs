using KB.Utils;
using KJ.Tourify.WebUI.Models;
using KJ.Tourify.WebUI.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KJ.Tourify.WebUI.Areas.Management.Controllers
{
    [Area("Management"), Authorize]
    public class BookPagesController : Controller
    {
        private readonly TourifyDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BookPagesController(TourifyDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.BookPages.FirstOrDefaultAsync();

            if (model is null)
            {
                model = new BookPage
                {
                    Id = Guid.NewGuid(),
                };

                await _context.BookPages.AddAsync(model);
                await _context.SaveChangesAsync();
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var model = await _context.BookPages.FirstOrDefaultAsync();

            if (model is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            BookPage model,
            IFormFile? BookImageUrl)
        {
            if (ModelState.IsValid)
            {
                if (BookImageUrl != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.BookImageUrl))
                        await FileUploader.DeleteAsync(_env, model.BookImageUrl);

                    model.BookImageUrl = await FileUploader.UploadAsync(_env, BookImageUrl);
                }

                _context.BookPages.Update(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}