using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Tourify.WebUI.Models.Entities
{
    [Table("GalleryCategories")]
    public class GalleryCategory
    {
        [Key]
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public Guid? GalleryPageId { get; set; }

        [ForeignKey(nameof(GalleryPageId))]
        public virtual GalleryPage? GalleryPage { get; set; }
        public virtual ICollection<GalleryItem>? GalleryItems { get; set; }
    }
}
