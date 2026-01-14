using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopWeb.Model;
using System.Text;
using System.Text.Json;

namespace ShopWeb.Pages
{
    public class AddToCartModel : PageModel
    {
        [BindProperty]
        public CartItem Item { get; set; }

        public async Task<IActionResult> OnGet(int id, string? name, string? description)
        {
            Item = new CartItem
            {
                ProductId = id,
                Name = name ?? string.Empty,
                Description = description ?? string.Empty,
                Quantity = 1
            };

            return Page();
        }


        public async Task<IActionResult> OnPost()
        {
            // Send the CartItem to the cart API
            string url = "https://localhost:7293/api/Cart"; // Adjust if needed
            HttpClient client = new HttpClient();

            var content = new StringContent(
                JsonSerializer.Serialize(Item),
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Product added to cart!";
                return RedirectToPage("Cart"); // Redirect to Cart page
            }
            else
            {
                TempData["fail"] = "Failed to add product to cart.";
                return Page(); // Stay on same page
            }
        }
    }
}
