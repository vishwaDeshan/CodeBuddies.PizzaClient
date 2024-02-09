using CodeBuddies.PizzaAPI.Models;
using CodeBuddies.PizzaClient.Services;
using Microsoft.AspNetCore.Components;

namespace CodeBuddies.PizzaClient.Pages.Customers
{
    public partial class AddCustomer
    {

        [Parameter]
        public int Id { get; set; }
        private CustomerModel customer = new CustomerModel();
        private string errorMessage;
        private string successMessage;
        [Inject]
        private ICustomerService customerService { get; set; }

        private async Task SubmitCustomer()
        {
            try
            {
                bool result = await customerService.SubmitCustomer(customer);
                if (result)
                {
                    successMessage = "Customer added successfully!";
                }
                else
                {
                    errorMessage = "Error adding customer: Unknown error occurred.";
                }
            }
            catch (HttpRequestException ex)
            {
                errorMessage = $"Error adding customer: {ex.Message}";
            }
        }
    }
}