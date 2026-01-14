using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopWeb.Helpers;
using ShopWeb.Model;
using System.Net.Http;

namespace ShopWeb.Pages
{
    public class ItemsModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public ItemsModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public List<MyItem> Items { get; set; }


        public async Task OnGetAsync()
        {
            // Replace this with your actual backend API endpoint
            Items = await _httpClient.GetFromJsonAsync<List<MyItem>>("https://localhost:7295/api/Product");
        }
        public IActionResult OnPostAddToCart(int id, string name, string description, int quantity)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();

            var existingItem = cart.FirstOrDefault(c => c.ProductId == id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity; // add more to existing quantity
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = id,
                    Name = name,
                    Description = description,
                    Quantity = quantity
                });
            }

            HttpContext.Session.SetObject("Cart", cart);
            return RedirectToPage("Cart");
        }


    }
}
