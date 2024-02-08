using CodeBuddies.PizzaAPI.Models;
using CodeBuddies.PizzaClient.Services;
using Microsoft.AspNetCore.Components;

namespace CodeBuddies.PizzaClient.Pages.Products
{
    public partial class Products
    {
        [Inject]
        private IProductService _productService { get; set; }
        private List<Product> productList = new List<Product>();

        //public Products(IProductService productService)
        //{
        //    _productService = productService;
        //}

        protected override async Task OnInitializedAsync()
        {
            await GetProductList();
        }

        private async Task GetProductList()
        {

            try
            {
                productList = (await _productService.GetAllProducts()).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching products: {ex.Message}");
            }
        }

        private async Task RemoveProduct(Product product)
        {
            var response = await _productService.DeleteProduct(product);
            productList.Remove(product);
            Console.WriteLine(response.ToString());
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Delete successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete product.");
            }
        }
    }
}