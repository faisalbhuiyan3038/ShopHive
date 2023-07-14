using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class Address
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [InverseProperty("Addresses")]
        public User User { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
