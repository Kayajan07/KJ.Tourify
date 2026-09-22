using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Tourify.WebUI.Models.Entities
{
    [Table("BookPages")]
    public class BookPage
    {
        [Key]
        public Guid Id { get; set; }
        public string? BookHeader { get; set; }
        public string? BookUpperTitle { get; set; }

        public string? BookTitle { get; set; }
        public string? BookDescription { get; set; }
        public string? BookImageUrl { get; set; }
        public string? BookButtonText { get; set; }
        public string? BookFormTittle { get; set; }
        public string? BookFormDescription { get; set; }
        public string? BookFormButtonText { get; set; }
    }
}