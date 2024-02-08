using CodeBuddies.PizzaAPI.Models;
using Microsoft.AspNetCore.Components;
using CodeBuddies.PizzaClient.Services;


namespace CodeBuddies.PizzaClient.Pages
{
    public partial class EditCustomer
    {

        [Parameter]
        public int Id { get; set; }
        private CustomerModel customer = new CustomerModel();
        private string errorMessage;
        private string successMessage;

        [Inject]
        private ICustomerService customerService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                customer = await customerService.GetCustomerById(Id);
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
                bool result = await customerService.EditCustomer(Id, customer);
                if (result)
                {
                    successMessage = "Customer edited successfully!";
                }
                else
                {
                    errorMessage = "Error editing customer: Unknown error occurred.";
                }
            }
            catch (HttpRequestException ex)
            {
                errorMessage = $"Error editing customer: {ex.Message}";
            }
        }
    }
}