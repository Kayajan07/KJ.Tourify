using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Tourify.WebUI.Models.Entities
{
    [Table("CreateTestimonialPages")]
    public class CreateTestimonialPage
    {
        [Key]
        public Guid Id { get; set; }

        public string? CreateTestimonialHeader { get; set; }
        public string? CreateTestimonialUpperTitle { get; set; }

        public string? CreateTestimonialTitle { get; set; }

        public string? CreateTestimonialSubTitle { get; set; }

        public string? CreateTestimonialDescription { get; set; }
        
        public string? CreateTestimonialTitle1 { get; set; }
        public string? CreateTestimonialDescription1 { get; set; }
        public string? CreateTestimonialIcon1 { get; set; }

        public string? CreateTestimonialTitle2 { get; set; }
        public string? CreateTestimonialDescription2 { get; set; }
        public string? CreateTestimonialIcon2 { get; set; }
        public string? CreateTestimonialTitle3 { get; set; }
        public string? CreateTestimonialDescription3 { get; set; }
        public string? CreateTestimonialIcon3 { get; set; }

        public string? CreateTestimonialButtonText { get; set; }

        public virtual ICollection<TourItem>? TourItems { get; set; }

    }
}
