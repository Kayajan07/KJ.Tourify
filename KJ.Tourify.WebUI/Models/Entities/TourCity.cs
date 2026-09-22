using System.ComponentModel.DataAnnotations;

namespace KJ.Tourify.WebUI.Models.Entities
{
    public class TourCity
    {
        [Key]
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<TourItem>? TourItems { get; set; }
    }
}
