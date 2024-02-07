using System.ComponentModel.DataAnnotations;

namespace CodeBuddies.PizzaAPI.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        //nullable
        public string? Address { get; set; }
        public string? Phone { get; set; }

        public ICollection<Order> Orders { get; set; } = null!;
    }
}
