using KB.Utils;
using KJ.Tourify.WebUI.Models;
using KJ.Tourify.WebUI.Models.Entities;
using KJ.Tourify.WebUI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

namespace KJ.Tourify.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly TourifyDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IConfiguration _configuration;
        public HomeController(TourifyDbContext context, IWebHostEnvironment hostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context
                .HomePages
                .AsNoTracking()
                .FirstOrDefaultAsync() ?? new HomePage();

            return View(model);
        }
        public async Task<IActionResult> About()
        {
            var model = await _context
                .AboutPages
                .AsNoTracking()
                .FirstOrDefaultAsync();

            SetHeaderImage(model?.AboutImageUrl);
            return View(model);
        }
        public async Task<IActionResult> Contact()
        {
            var model = await _context
                .ContactPages
                .AsNoTracking()
                .FirstOrDefaultAsync();

            SetHeaderImage(await _context.HomePages.Select(x => x.ImageUrl3).FirstOrDefaultAsync());
            return View(model);
        }
        public async Task<IActionResult> Services()
        {
            var model = await _context
               .ServicePages
               .AsNoTracking()
               .FirstOrDefaultAsync();

            SetHeaderImage(await _context.HomePages.Select(x => x.ImageUrl2).FirstOrDefaultAsync());
            return View(model);
        }
        public async Task<IActionResult> Tours(Guid? cityId, int? guests)
        {
            var model = await _context
                .TourPages
                .AsNoTracking()
                .FirstOrDefaultAsync() ?? new TourPage();

            var query = _context
                .TourItems
                .AsNoTracking()
                .Include(x => x.City)
                .AsQueryable();

            if (cityId.HasValue)
                query = query.Where(x => x.TourCityId == cityId.Value);

            var tourItems = await query.OrderBy(x => x.Title).ToListAsync();

            if (guests is > 0)
                tourItems = tourItems
                    .Where(x => TourFormat.Capacity(x.TourPerson) is not int capacity || capacity >= guests)
                    .ToList();

            model.TourItems = tourItems;

            SetHeaderImage(await _context.TourItems
                .OrderBy(x => x.Title)
                .Select(x => x.TourImageUrl)
                .FirstOrDefaultAsync(x => x != null && x != ""));
            return View(model);
        }
        public async Task<IActionResult> Booking()
        {
            var model = await _context
                .BookPages
                .AsNoTracking()
                .FirstOrDefaultAsync();

            SetHeaderImage(await _context.HomePages.Select(x => x.HomeAboutImageUrl).FirstOrDefaultAsync());
            return View(model);
        }
        
        public async Task<IActionResult> Tour(Guid id)
        {
            var model = await _context
                .TourItems
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.City)
                .Include(x => x.TourTestimonialItems)
                .FirstOrDefaultAsync();

            if (model is null)
                return RedirectToAction(nameof(Tours));

            SetHeaderImage(model.TourImageUrl);
            return View(model);
        }
        public async Task<IActionResult> Gallery()
        {
            var model = await _context
                .GalleryPages
                .AsNoTracking()
                .FirstOrDefaultAsync() ?? new GalleryPage();

            model.GalleryCategories = await _context
                .GalleryCategories
                .AsNoTracking()
                .ToListAsync();

            model.GalleryItems = await _context
                .GalleryItems
                .AsNoTracking()
                .Include(x => x.GalleryCategory)
                .ToListAsync();

            SetHeaderImage(model.GalleryItems
                .Where(x => !string.IsNullOrWhiteSpace(x.GalleryImageUrl))
                .OrderBy(x => x.Title)
                .Select(x => x.GalleryImageUrl)
                .FirstOrDefault());
            return View(model);
        }
        public async Task<IActionResult> Guides()
        {
            var model = await _context
                .GuidePages
                .AsNoTracking()
                .FirstOrDefaultAsync();

            SetHeaderImage(await _context.HomePages.Select(x => x.ImageUrl1).FirstOrDefaultAsync());
            return View(model);
        }
        
        public async Task<IActionResult> CreateTestimonial(Guid tourItemId)
        {
            var model = await _context
                .CreateTestimonialPages
                .AsNoTracking()
                .FirstOrDefaultAsync();

            model.TourItems = await _context
                .TourItems
                .AsNoTracking()
                .Where(x => x.Id == tourItemId)
                .ToListAsync();

            SetHeaderImage(model.TourItems.FirstOrDefault()?.TourImageUrl);
            return View(model);
        }

        
        
        
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTestimonial(TourTestimonialItem model, IFormFile? ProfileImageFile)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();
                model.ProfileImageUrl = await UploadProfileImageAsync(ProfileImageFile);

                await _context.TourTestimonialItems.AddAsync(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Tour), new { id = model.TourItemId });
            }

            var page = await _context
                .CreateTestimonialPages
                .AsNoTracking()
                .FirstOrDefaultAsync();

            page.TourItems = await _context
                .TourItems
                .AsNoTracking()
                .Where(x => x.Id == model.TourItemId)
                .ToListAsync();

            SetHeaderImage(page.TourItems.FirstOrDefault()?.TourImageUrl);
            return View(page);
        }
        
        
        
        
        public IActionResult NotFoundPage()
        {
            return View();
        }

        
        
        
        
        
        private void SetHeaderImage(string? imageUrl)
        {
            if (!string.IsNullOrWhiteSpace(imageUrl))
                ViewData["HeaderImage"] = ImagePath.Resolve(imageUrl);
        }

        private async Task<string?> UploadProfileImageAsync(IFormFile? profileImage)
        {
            if (profileImage is null || profileImage.Length == 0)
                return null;

            Directory.CreateDirectory(Path.Combine(_hostEnvironment.WebRootPath, "uploads"));
            return await FileUploader.UploadAsync(_hostEnvironment, profileImage);
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(
    string name,
    string email,
    string subject,
    string message)
        {
            var smtpSettings = _configuration.GetSection("Smtp");
            string mailAddress = smtpSettings["Email"]!;

            MailMessage mail = new MailMessage();
            mail.Subject = subject;
            mail.Sender = new MailAddress(mailAddress);
            mail.Body = $"Gönderen: {name} \n\r" +
                        $"Email: {email} \n\r" +
                        $"Mesaj: {message}";
            mail.IsBodyHtml = false;
            mail.From = new MailAddress(mailAddress);
            mail.To.Add(new MailAddress(mailAddress));

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(mailAddress, smtpSettings["Password"]);
            smtp.Host = smtpSettings["Host"];
            smtp.Port = smtpSettings.GetValue<int>("Port");
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return Json(new { });
        }
    }
}

