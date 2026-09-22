using KJ.Tourify.WebUI.Models;
using KJ.Tourify.WebUI.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KJ.Tourify.WebUI.Areas.Management.Controllers
{
    [Area("Management"), Authorize]
    public class ServicePagesController : Controller
    {
        private readonly TourifyDbContext _context;

        public ServicePagesController(TourifyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.ServicePages.FirstOrDefaultAsync();

            if (model is null)
            {
                model = new ServicePage
                {
                    Id = Guid.NewGuid(),
                };

                await _context.ServicePages.AddAsync(model);
                await _context.SaveChangesAsync();
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var model = await _context.ServicePages.FirstOrDefaultAsync();

            if (model is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServicePage model)
        {
            if (ModelState.IsValid)
            {
                _context.ServicePages.Update(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}