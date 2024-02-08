using CodeBuddies.PizzaAPI.Models;
using CodeBuddies.PizzaClient.Services;
using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;

namespace CodeBuddies.PizzaClient.Pages.Products
{
    public partial class UpdateProduct
    {
        [Parameter]
        public int id { get; set; }
        private Product product = new Product();
        [Inject]
        private IProductService _productService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                product = await _productService.GetProductById(id);
                Console.WriteLine(product.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading product: {ex.Message}");
            }
        }

        private async Task HandleUpdateProduct()
        {
            try
            {
                var response = await _productService.UpdateProduct(id ,product);
                Console.WriteLine(response.ToString());
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Update successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to update product.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
            }
        }
    }
}