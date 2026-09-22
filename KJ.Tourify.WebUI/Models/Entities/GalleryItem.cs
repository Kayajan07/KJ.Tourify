using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Tourify.WebUI.Models.Entities
{
    [Table("GalleryItems")]
    public class GalleryItem
    {
        [Key]
        public Guid Id { get; set; }

        
        public string? Title { get; set; }

        public string? GalleryImageUrl { get; set; }

       

        
        public Guid GalleryCategoryId { get; set; }

        [ForeignKey(nameof(GalleryCategoryId))]
        public virtual GalleryCategory? GalleryCategory { get; set; }

        public Guid? GalleryPageId { get; set; }

        [ForeignKey(nameof(GalleryPageId))]
        public virtual GalleryPage? GalleryPage { get; set; }
    }
}