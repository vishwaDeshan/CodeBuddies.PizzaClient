using CodeBuddies.PizzaAPI.Models;
using CodeBuddies.PizzaClient.Pages.Products;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace CodeBuddies.PizzaClient.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<HttpResponseMessage> CreateNewProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<HttpResponseMessage> UpdateProduct(int id,Product product);
        Task<HttpResponseMessage> DeleteProduct(Product product);
    }
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;        

        public ProductService(HttpClient httpClient) 
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                // Fetch all products from the API
                return await httpClient.GetFromJsonAsync<IEnumerable<Product>>($"https://localhost:7158/api/Products");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching products: {ex.Message}");
                return null;
            }
        }

       public async Task<HttpResponseMessage> CreateNewProduct(Product product)
        {
            try
            {
                HttpResponseMessage response = await httpClient.PostAsJsonAsync($"https://localhost:7158/api/Products", product);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error posting products: {ex.Message}");
                return null;
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await httpClient.GetFromJsonAsync<Product>($"https://localhost:7158/api/Products/{id}");

            if (product == null)
            {
                throw new ArgumentException($"Can not find product with {id}");
            }

            return product;
        }

        public async Task<HttpResponseMessage> UpdateProduct(int id ,Product product)
        {
            try
            {
                HttpResponseMessage response = await httpClient.PutAsJsonAsync($"https://localhost:7158/api/Products/{id}", product);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating products: {ex.Message}");
                return null;
            }
        }

        public async Task<HttpResponseMessage> DeleteProduct(Product product)
        {
            try
            {
                HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:7158/api/Products/{product.Id}");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting products: {ex.Message}");
                return null;
            }
        }
    }
}
