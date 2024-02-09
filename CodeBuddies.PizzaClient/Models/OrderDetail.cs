using System.ComponentModel.DataAnnotations;

namespace CodeBuddies.PizzaAPI.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        //public Order Order { get; set; } = null!;
        public int OrderId { get; set; }
        //public Product Product { get; set; } = null!;
        public int ProductId { get; set; }
    }
}
