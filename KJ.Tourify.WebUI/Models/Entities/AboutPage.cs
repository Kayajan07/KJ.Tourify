using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Tourify.WebUI.Models.Entities
{
    [Table("AboutPages")]
    public class AboutPage
    {
        [Key]
        public Guid Id { get; set; }
        public string? AboutHeader { get; set; }
        public string? AboutUpperTitle { get; set; }

        public string? AboutTitle { get; set; }
        public string? AboutDescription { get; set; }
        public string? AboutImageUrl { get; set; }
        public string? AboutGuideTitle { get; set; }
        public string? AboutGuideDescription { get; set; }
        public string? AboutGuideButtonText { get; set; }
    }
}
