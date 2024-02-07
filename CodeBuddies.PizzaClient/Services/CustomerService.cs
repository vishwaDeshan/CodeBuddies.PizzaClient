using CodeBuddies.PizzaAPI.Models;
using CodeBuddies.PizzaClient.Pages;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace CodeBuddies.PizzaClient.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerModel>> GetCustomers();
        Task<bool> DeleteCustomer(CustomerModel customer);
        Task<bool> SubmitCustomer(CustomerModel customer);

    }
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient httpClient;
        public CustomerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<CustomerModel>> GetCustomers()
        {
            var customerData = await httpClient.GetFromJsonAsync<List<CustomerModel>>("https://localhost:7158/api/Customers");
            return customerData;
        }


        public async Task<bool> DeleteCustomer(CustomerModel customer)
        {
            try
            {
                HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:7158/api/Customers/{customer.Id}");
                return response.IsSuccessStatusCode;
            }
             catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message}");
            }
        }

        public async Task<bool> SubmitCustomer(CustomerModel customer)
        {
            try
            {
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:7158/api/Customers", customer);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"ErroR: {ex.Message}");
            }
        }
    }
}
