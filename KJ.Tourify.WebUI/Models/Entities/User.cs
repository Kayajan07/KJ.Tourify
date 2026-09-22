using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Tourify.WebUI.Models.Entities
{
    [Table("Users")]
    public class User
    {
        [Key] public Guid Id { get; set; }

        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
