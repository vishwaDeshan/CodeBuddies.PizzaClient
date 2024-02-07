using CodeBuddies.PizzaAPI.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace CodeBuddies.PizzaClient.Pages
{
    public partial class AddCustomer
    {

        [Parameter]
        public int Id { get; set; }
        private CustomerModel customer = new CustomerModel();
        private string errorMessage;
        private string successMessage;

        private async Task SubmitCustomer()
        {
            try
            {
                HttpResponseMessage response = await http.PostAsJsonAsync("https://localhost:7158/api/Customers", customer);
                response.EnsureSuccessStatusCode();
                successMessage = "Customer added successfully!";
            }
            catch (HttpRequestException ex)
            {
                errorMessage = $"Error adding customer: {ex.Message}";
            }
        }
    }
}