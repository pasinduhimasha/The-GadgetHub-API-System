using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopWeb.Helpers;
using ShopWeb.Model;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace ShopWeb.Pages
{
    public class CartModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public CartModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public List<CartItem> CartItems { get; set; } = new();

        public void OnGet()
        {
            CartItems = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();
        }

        public IActionResult OnPostRemove(int id)
        {
            CartItems = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartItems.RemoveAll(c => c.ProductId == id);
            HttpContext.Session.SetObject("Cart", CartItems);
            return RedirectToPage();
        }

        public IActionResult OnPostUpdateQuantity(int id, int quantity)
        {
            CartItems = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();
            var item = CartItems.FirstOrDefault(c => c.ProductId == id);
            if (item != null)
            {
                item.Quantity = quantity;
            }
            HttpContext.Session.SetObject("Cart", CartItems);
            return RedirectToPage();
        }

        // This is where your single item checkout handler goes
        public async Task<IActionResult> OnPostCheckoutSingleAsync(int id)
        {
            CartItems = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();

            var itemToCheckout = CartItems.FirstOrDefault(c => c.ProductId == id);

            if (itemToCheckout == null)
            {
                ModelState.AddModelError("", "Item not found in the cart.");
                return Page();
            }

            var orderPayload = new
            {
                Items = new[]
                {
                    new
                    {
                        ProductName = itemToCheckout.Name,
                        Quantity = itemToCheckout.Quantity
                    }
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(orderPayload), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7295/api/Orders", content);

            if (response.IsSuccessStatusCode)
            {
                var notificationId = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(notificationId))
                {
                    ModelState.AddModelError("", "Received empty notification ID.");
                    return Page();
                }

                // Remove checked out item from cart
                CartItems.Remove(itemToCheckout);
                HttpContext.Session.SetObject("Cart", CartItems);

                var idStr = notificationId.Trim('"');
                return RedirectToPage("OrderNotification", new { id = idStr });
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", $"Order failed: {errorMessage}");
                return Page();
            }
        }
    }
}
