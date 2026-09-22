using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace KJ.Tourify.WebUI.Models.Entities
{
    [Table("ContactPages")]
    public class ContactPage
    {
        [Key]
        public Guid Id { get; set; }

        public string? ContactHeader { get; set; }
        public string? ContactUpperTitle { get; set; }

        public string? ContactTitle { get; set; }

        public string? ContactSubTitle { get; set; }

        public string? ContactDescription { get; set; }

        public string? ContactLocationTitle { get; set; }
        public string? ContactLocationIcon { get; set; }

        public string? ContactLocationDescription { get; set; }


        public string? ContactPhoneTitle { get; set; }
        public string? ContactPhone1 { get; set; }

        public string? ContactPhone2 { get; set; }

        public string? ContactPhoneIcon { get; set; }
        public string? ContactEmailTitle { get; set; }
        public string? ContactEmail1 { get; set; }

        public string? ContactEmail2 { get; set; }
        public string? ContactEmailIcon { get; set; }


        public string? ContactButtonText { get; set; }

        public string? ContactMapUrl{ get; set; }


    }
}
