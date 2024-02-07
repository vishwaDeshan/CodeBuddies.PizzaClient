using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeBuddies.PizzaAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [Column(TypeName = " decimal(10,2)")]
        public decimal Price { get; set; }
    }
}
