
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Tourify.WebUI.Models.Entities
{
    [Table("TourItems")]
    public class TourItem
    {
        [Key]
        public Guid Id { get; set; }

        public string? HowMuchMoney { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? TourImageUrl { get; set; }

        public string? TourLocation { get; set; }

        public string? TourDay { get; set; }

        public string? TourPerson { get; set; }
        
        public Guid? TourPageId { get; set; }

        [ForeignKey(nameof(TourPageId))]
        public virtual TourPage? TourPage { get; set; }


        public Guid TourCityId { get; set; }

        [ForeignKey(nameof(TourCityId))]
        public virtual TourCity? City { get; set; }

        public Guid? CreateTestimonialPageId { get; set; }

        [ForeignKey(nameof(CreateTestimonialPageId))]
        public virtual CreateTestimonialPage? CreateTestimonialPage { get; set; }

        public virtual ICollection<TourTestimonialItem>? TourTestimonialItems { get; set; }
    }
}


