using CodeBuddies.PizzaAPI.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace CodeBuddies.PizzaClient.Pages
{
    public partial class EditCustomer
    {

        [Parameter]
        public int Id { get; set; }
        private CustomerModel customer = new CustomerModel();
        private string errorMessage;
        private string successMessage;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                customer = await http.GetFromJsonAsync<CustomerModel>($"https://localhost:7158/api/Customers/{Id}");
            }
            catch (Exception ex)
            {
                errorMessage = "An error occurred while retrieving customer data: " + ex.Message;
            }
        }

        private async Task SaveCustomer()
        {
            try
            {
                HttpResponseMessage response = await http.PutAsJsonAsync($"https://localhost:7158/api/Customers/{customer.Id}", customer);
                response.EnsureSuccessStatusCode();
                successMessage = "Customer Edited successfully!";
            }
            catch (HttpRequestException ex)
            {
                errorMessage = $"Error editing customer: {ex.Message}";
            }
        }
    }
}