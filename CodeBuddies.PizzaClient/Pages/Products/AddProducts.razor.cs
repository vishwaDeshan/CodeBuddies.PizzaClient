using CodeBuddies.PizzaAPI.Models;
using CodeBuddies.PizzaClient.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace CodeBuddies.PizzaClient.Pages.Products
{
    public partial class AddProducts
    {
        [Inject]
        private IProductService _productService { get; set; }
        Product product = new Product();

        private async Task AddProduct()
        {
            try
            {
                var newProduct = new Product
                {
                    Name = product.Name,
                    Price = product.Price
                };

                var response = await _productService.CreateNewProduct(newProduct);

                if (response.IsSuccessStatusCode)
                {
                    //reset the form
                    newProduct = new Product();
                }
                else
                {
                    Console.WriteLine("Failed to save product.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving product: {ex.Message}");
            }
        }
    }
}