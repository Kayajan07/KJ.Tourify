using KJ.Tourify.WebUI.Models;
using KJ.Tourify.WebUI.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KJ.Tourify.WebUI.Areas.Management.Controllers
{
    [Area("Management"), Authorize]
    public class ContactPagesController : Controller
    {
        private readonly TourifyDbContext _context;

        public ContactPagesController(TourifyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.ContactPages.FirstOrDefaultAsync();

            if (model is null)
            {
                model = new ContactPage
                {
                    Id = Guid.NewGuid(),
                };

                await _context.ContactPages.AddAsync(model);
                await _context.SaveChangesAsync();
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var model = await _context.ContactPages.FirstOrDefaultAsync();

            if (model is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContactPage model)
        {
            if (ModelState.IsValid)
            {
                _context.ContactPages.Update(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}