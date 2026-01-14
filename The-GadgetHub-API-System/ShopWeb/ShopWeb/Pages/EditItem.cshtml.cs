using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;
using ShopWeb.Model;

namespace ShopWeb.Pages
{
    public class EditItemModel : PageModel
    {
        [BindProperty]
        public MyItem item { get; set; }
        public async Task OnGet(int id)
        {
            string url = "https://localhost:7293/api/Quotation" + id;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content=await response.Content.ReadAsStringAsync();
                item = JsonSerializer.Deserialize<MyItem>(content,
                    new JsonSerializerOptions { 
                        PropertyNameCaseInsensitive = true
                    });

            }
        }
        public async Task<ActionResult> OnPost()
        {
            string url = "https://localhost:7293/api/Quotation" + item.Id;
            HttpClient client = new HttpClient();
            if (!string.IsNullOrEmpty(Request.Form["btnUpdate"]))
            {
                HttpContent content = new StringContent(
                                        JsonSerializer.Serialize(item),
                                        Encoding.UTF8,
                                        "application/json");
                HttpResponseMessage response = await client.PutAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Item updated successfully";
                    return RedirectToPage("Items");
                }
                else
                {
                    TempData["fail"] = "Fail to update Item";
                    return RedirectToPage("Items");
                }
            }
            else if (!string.IsNullOrEmpty(Request.Form["btnDelete"]))
            {
                HttpResponseMessage response = await client.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Item deleted successfully";
                    return RedirectToPage("Items");
                }
                else
                {
                    TempData["fail"] = "Fail to delete item";
                    return RedirectToPage("Items");
                }

            }
            else
            {
                string url1 = "https://localhost:7293/api/Quotation";
                HttpContent content = new StringContent(
                                        JsonSerializer.Serialize(item),
                                        Encoding.UTF8,
                                        "application/json");
                HttpResponseMessage response = await client.PostAsync(url1, content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Item added successfully";
                    return RedirectToPage("Items");
                }
                else
                {
                    TempData["fail"] = "Fail to add Item ";
                    return RedirectToPage("Items");
                }
            }
        }
    }
}
