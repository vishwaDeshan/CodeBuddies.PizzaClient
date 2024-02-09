using CodeBuddies.PizzaAPI.Models;
using CodeBuddies.PizzaClient.Services;
using Microsoft.AspNetCore.Components;

namespace CodeBuddies.PizzaClient.Pages.OrderDetails
{
    public partial class AddOrderDetails
    {
        [Parameter]
        public int Id { get; set; }
        private OrderDetail orderDetail = new OrderDetail();
        private string errorMessage;
        private string successMessage;
        [Inject]
        private IOrderDetailsService orderDetailsService {  get; set; }

        private async Task SubmitOrderDetails()
        {
            try
            {
                bool result = await orderDetailsService.AddOrderDetailsAsync(orderDetail);
                if (result)
                {
                    successMessage = "Order Details added successfully!";
                }
                else
                {
                    errorMessage = "Error adding order Details: Unknown error occurred.";
                }
            }
            catch (HttpRequestException ex)
            {
                errorMessage = $"Error adding order Details: {ex.Message}";
            }
        }
    }
}