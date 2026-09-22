using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Tourify.WebUI.Models.Entities
{
    [Table("Guides")]
    public class GuidePage
    {
        [Key]
        public Guid Id { get; set; }
        
        public string? GuideHeader { get; set; }
        public string? GuideUpperTitle { get; set; }

        public string? GuideTitle { get; set; }

        public string? GuideName1 { get; set; }

        public string? GuideName2 { get; set; }

        public string? GuideName3 { get; set; }

        public string? GuideName4 { get; set; }

        public string? GuideDescription1 { get; set; }
        public string? GuideDescription2 { get; set; }
        public string? GuideDescription3 { get; set; }
        public string? GuideDescription4 { get; set; }
        public string? GuideImageUrl1 { get; set; }
        public string? GuideImageUrl2 { get; set; }
        public string? GuideImageUrl3 { get; set; }
        public string? GuideImageUrl4 { get; set; }



    }
}
