using System.ComponentModel.DataAnnotations;

namespace CodeBuddies.PizzaAPI.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime OrderFullFilled { get; set; }
        public CustomerModel Customer { get; set; } = null!;
        public ICollection<OrderDetail> OrderDetails { get; set; } = null!;

    }
}
