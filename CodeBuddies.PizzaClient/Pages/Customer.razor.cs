using CodeBuddies.PizzaAPI.Models;
using CodeBuddies.PizzaClient.Services;
using Microsoft.AspNetCore.Components;

namespace CodeBuddies.PizzaClient.Pages
{
    public partial class Customer
    {

        private List<CustomerModel> customerData = new List<CustomerModel>();
        private string errorMessage;
        private string sucessMessage;

        [Inject]
        private ICustomerService customerService { get; set; }

        private async Task Delete(CustomerModel customer)
        {
            bool deletionResult = await customerService.DeleteCustomer(customer);
            if (deletionResult)
            {
                customerData.Remove(customer);
                sucessMessage = "User deleted successfully";
            }
            else
            {
                errorMessage = "Failed to delete the user. Please try again.";
            }
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                customerData = await customerService.GetCustomers();
            }
            catch (Exception ex)
            {
                errorMessage = "An error occurred while retrieving customer data: " + ex.Message;
            }
        }
    }
}