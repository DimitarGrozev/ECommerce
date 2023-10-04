using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECommerce.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [RegularExpression(@"^[A-Za-z\s]+,\s\d{5}\s\d+,\s[A-Za-z\s]+$")]
        public string Address { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
    }
}
