using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Tourify.WebUI.Models.Entities
{
    [Table("Subscribe")]
    public class Subscribe
    {
        [Key]
        public Guid Id { get; set; }
        public string? UpperTitle { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
