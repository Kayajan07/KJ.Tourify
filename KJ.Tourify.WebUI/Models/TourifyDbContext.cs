using KJ.Tourify.WebUI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KJ.Tourify.WebUI.Models
{
    public class TourifyDbContext : DbContext
    {
        public TourifyDbContext()
        {}

        public TourifyDbContext(DbContextOptions<TourifyDbContext> options) : base(options)
        {}

        public DbSet<AboutPage> AboutPages { get; set; }
        public DbSet<ContactPage> ContactPages { get; set; }
        
        public DbSet<GalleryCategory> GalleryCategories { get; set; }
        public DbSet<GalleryItem> GalleryItems { get; set; }
        public DbSet<GalleryPage> GalleryPages { get; set; }
        public DbSet<GuidePage> GuidePages { get; set; }
        public DbSet<BookPage> BookPages { get; set; }
        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<ServicePage> ServicePages { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<TourCity> TourCities { get; set; }
        public DbSet<TourItem> TourItems { get; set; }
        public DbSet<TourPage> TourPages { get; set; }
        public DbSet<CreateTestimonialPage> CreateTestimonialPages { get; set; }
        public DbSet<User> Users { get; set; }



        public DbSet<TourTestimonialItem> TourTestimonialItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TourItem>()
                .HasOne(x => x.City)
                .WithMany(x => x.TourItems)
                .HasForeignKey(x => x.TourCityId);

            modelBuilder.Entity<GalleryItem>()
                .HasOne(x => x.GalleryCategory)
                .WithMany(x => x.GalleryItems)
                .HasForeignKey(x => x.GalleryCategoryId);

            modelBuilder.Entity<TourTestimonialItem>()
                .HasOne(x => x.TourItem)
                .WithMany(x => x.TourTestimonialItems)
                .HasForeignKey(x => x.TourItemId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
