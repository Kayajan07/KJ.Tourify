using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Tourify.WebUI.Models.Entities
{
    [Table("Services")]
    public class ServicePage
    {
        [Key]
        public Guid Id { get; set; }
        public string? ServiceHeader { get; set; }
        public string? ServiceUpperTitle { get; set; }
        public string? ServiceTitle { get; set; }
        public string? Service1Icon { get; set; }
        public string? Service1Title { get; set; }
        public string? Service1Description { get; set; }
        public string? Service2Icon { get; set; }
        public string? Service2Title { get; set; }
        public string? Service2Description { get; set; }
        public string? Service3Icon { get; set; }
        public string? Service3Title { get; set; }
        public string? Service3Description { get; set; }
        public string? Service4Icon { get; set; }
        public string? Service4Title { get; set; }
        public string? Service4Description { get; set; }
        public string? ServicePageButtonText { get; set; }


    }
}
