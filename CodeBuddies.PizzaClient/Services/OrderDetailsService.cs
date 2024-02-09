using CodeBuddies.PizzaAPI.Models;
using System.Net.Http.Json;

namespace CodeBuddies.PizzaClient.Services
{
    public interface IOrderDetailsService
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetails();
        Task<bool> AddOrderDetailsAsync(OrderDetail orderDetail);
        Task<OrderDetail> GetOrderDetailById(int id);

    }

    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly HttpClient httpClient;
        public OrderDetailsService(HttpClient httpClient)
        {

            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetails()
        {
            try
            {
                return await httpClient.GetFromJsonAsync<IEnumerable<OrderDetail>>("https://localhost:7158/api/TestOrderDetails");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching products: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AddOrderDetailsAsync(OrderDetail orderDetail)
        {
            try
            {
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:7158/api/TestOrderDetails", orderDetail);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"Error: {ex.Message}");
            }
        }


        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            try
            {
                var orderDetails = await httpClient.GetFromJsonAsync<OrderDetail>($"https://localhost:7158/api/TestOrderDetails/{id}");
                return orderDetails;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving order details data: {ex.Message}");
            }
        }
    }
}
