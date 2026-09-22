using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Tourify.WebUI.Models.Entities
{
    [Table("TourTestimonialItems")]
    public class TourTestimonialItem
    {
        [Key]
        public Guid Id { get; set; }

        public string? FullName { get; set; }

        public string? ProfileImageUrl { get; set; }

        public string? Address { get; set; }

        public string? Description { get; set; }

        
        public Guid TourItemId { get; set; }

        [ForeignKey(nameof(TourItemId))]
        public virtual TourItem? TourItem { get; set; }
    }
}
