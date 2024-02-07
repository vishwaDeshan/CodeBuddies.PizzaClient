using CodeBuddies.PizzaAPI.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace CodeBuddies.PizzaClient.Pages
{
    public partial class Customer
    {

        private List<CustomerModel> customerData = new List<CustomerModel>();
        private string errorMessage;
        private string sucessMessage;

        private async Task GetCustomers()
        {
            try
            {
                customerData = await http.GetFromJsonAsync<List<CustomerModel>>("https://localhost:7158/api/Customers");
            }
            catch (Exception ex)
            {
                errorMessage = "An error occurred while retrieving customer data: " + ex.Message;
            }
        }

        private async Task Delete(CustomerModel customer)
        {
            try
            {
                HttpResponseMessage response = await http.DeleteAsync($"https://localhost:7158/api/Customers/{customer.Id}");
                customerData.Remove(customer);
                sucessMessage = "User deleted sucessfully";
            }
            catch (Exception ex)
            {
                errorMessage = "An error occurred while deleting the customer: " + ex.Message;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await GetCustomers();
        }
    }
}