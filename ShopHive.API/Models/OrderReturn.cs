using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class OrderReturn
    {
        public int Id { get; set; }

       
        public int OrderId { get; set; }

        
        public Order Order { get; set; }

        public string ReturnStatus { get; set; }
    }
}
