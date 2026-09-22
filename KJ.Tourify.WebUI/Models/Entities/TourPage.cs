using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Tourify.WebUI.Models.Entities
{
    [Table("TourPages")]
    public class TourPage
    {
        [Key]
        public Guid Id { get; set; }

        public string? TourHeader { get; set; }

        public string? TourUpperTitle { get; set; }

        public string? TourTitle { get; set; }

        public virtual ICollection<TourItem>? TourItems { get; set; }
    }
}
