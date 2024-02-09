using CodeBuddies.PizzaAPI.Models;
using CodeBuddies.PizzaClient.Pages;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace CodeBuddies.PizzaClient.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerModel>> GetCustomers();
        Task<CustomerModel> GetCustomerById(int id);
        Task<bool> DeleteCustomer(CustomerModel customer);
        Task<bool> SubmitCustomer(CustomerModel customer);
        Task<bool> EditCustomer(int id, CustomerModel customer);


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

        public async Task<CustomerModel> GetCustomerById(int id)
        {
            try
            {
                var customer = await httpClient.GetFromJsonAsync<CustomerModel>($"https://localhost:7158/api/Customers/{id}");
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving customer data: {ex.Message}");
            }
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
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<bool> SubmitCustomer(CustomerModel customer)
        {
            try
            {
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:7158/api/Customers", customer);
                return response.IsSuccessStatusCode; ;
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"ErroR: {ex.Message}");
            }
        }

        public async Task<bool> EditCustomer(int id, CustomerModel customer)
        {
            try
            {
                HttpResponseMessage response = await httpClient.PutAsJsonAsync($"https://localhost:7158/api/Customers/{id}", customer);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"ErroR: {ex.Message}");
            }
        }
    }
}
