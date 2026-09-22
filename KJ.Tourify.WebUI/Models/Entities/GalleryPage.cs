using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Tourify.WebUI.Models.Entities
{
    [Table("GalleryPages")]
    public class GalleryPage
    {
        [Key]
        public Guid Id { get; set; }

        public string? GalleryHeader { get; set; }
        public string? GalleryUpperTitle { get; set; }

        public string? GalleryTitle { get; set; }

        public string? GalleryDescription { get; set; }
        public virtual ICollection<GalleryItem>? GalleryItems { get; set; }

        public virtual ICollection<GalleryCategory>? GalleryCategories { get; set; }
    }
}
