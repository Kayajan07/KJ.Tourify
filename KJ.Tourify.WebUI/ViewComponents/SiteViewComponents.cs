using KJ.Tourify.WebUI.Models;
using KJ.Tourify.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace KJ.Tourify.WebUI.ViewComponents
{
    public class FeaturedToursViewComponent : ViewComponent
    {
        private readonly TourifyDbContext _context;
        public FeaturedToursViewComponent(TourifyDbContext context) => _context = context;

        public async Task<IViewComponentResult> InvokeAsync(int count = 3)
        {
            var model = await _context
                .TourItems
                .AsNoTracking()
                .Include(x => x.City)
                .OrderBy(x => x.Title)
                .Take(count)
                .ToListAsync();

            return View(model);
        }
    }

    public class GalleryStripViewComponent : ViewComponent
    {
        private readonly TourifyDbContext _context;
        public GalleryStripViewComponent(TourifyDbContext context) => _context = context;

        public async Task<IViewComponentResult> InvokeAsync(int count = 8)
        {
            var model = await _context
                .GalleryItems
                .AsNoTracking()
                .Include(x => x.GalleryCategory)
                .Where(x => x.GalleryImageUrl != null && x.GalleryImageUrl != "")
                .OrderBy(x => x.Title)
                .Take(count)
                .ToListAsync();

            return View(model);
        }
    }

    public class StatsBarViewComponent : ViewComponent
    {
        private readonly TourifyDbContext _context;
        public StatsBarViewComponent(TourifyDbContext context) => _context = context;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new StatsViewModel(
                DestinationCount: await _context.TourCities.CountAsync(),
                TourCount: await _context.TourItems.CountAsync(),
                TravelerCount: await _context.TourTestimonialItems.CountAsync());

            return View(model);
        }
    }

    public class TourSearchViewComponent : ViewComponent
    {
        private readonly TourifyDbContext _context;
        public TourSearchViewComponent(TourifyDbContext context) => _context = context;

        public async Task<IViewComponentResult> InvokeAsync(bool inline = false)
        {
            var query = HttpContext.Request.Query;

            var model = new TourSearchViewModel
            {
                Cities = await _context.TourCities.AsNoTracking().OrderBy(x => x.Name).ToListAsync(),
                CityId = Guid.TryParse(query["cityId"], out var cityId) ? cityId : null,
                Date = DateOnly.TryParseExact(query["date"], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date) ? date : null,
                Guests = int.TryParse(query["guests"], out var guests) && guests > 0 ? guests : null,
                Inline = inline
            };

            return View(model);
        }
    }
}
