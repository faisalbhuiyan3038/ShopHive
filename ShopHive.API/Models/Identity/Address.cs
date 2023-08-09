using ShopHive.API.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class Address
    {
        public int Id { get; set; }

        
        public string AppUserId { get; set; }

        [Required]
        public AppUser AppUser { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
