

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Tourify.WebUI.Models.Entities
{

    [Table("HomePages")]
    public class HomePage
    {
        [Key]
        public Guid Id { get; set; }

        public string? UpperTitle { get; set; }
        public string? Title1 { get; set; }

        public string? Title2 { get; set; }

        public string? Title3 { get; set; }
        public string? Description { get; set; }

        public string? ImageUrl1 { get; set; }

        public string? ImageUrl2 { get; set; }

        public string? ImageUrl3 { get; set; }

        public string? HomeButtonText { get; set; }

        public string? HomeAboutUpperTitle { get; set; }

        public string? HomeAboutTitle { get; set; }

        public string? HomeAboutDescription { get; set; }

        public string? HomeAboutFeatures { get; set; }

        public string? HomeAboutImageUrl { get; set; }

        public string? HomeAboutButtonText { get; set; }
        public string? HomeAboutServicesTitle { get; set; }

        public string? HomeAboutServicesButtonText { get; set; }

        public string? HomeAboutService1 { get; set; }

        public string? HomeAboutService2 { get; set; }

        public string? HomeAboutService3 { get; set; }

        public string? HomeAboutService4 { get; set; }
        public string? HomePageDestinationTitle { get; set; }
        public string? HomeDestinationDescription { get; set; }
        public string? HomeDestinationButtonText { get; set; }
    }
}
