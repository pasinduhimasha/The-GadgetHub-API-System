using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopWeb.Helpers;
using ShopWeb.Model;
using System.Text;
using System.Text.Json;

public class OrderNotificationModel : PageModel
{
    private readonly HttpClient _httpClient;

    public OrderNotificationModel(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    [BindProperty(SupportsGet = true)]
    public string Id { get; set; } = string.Empty;

    [BindProperty]
    public int NotificationIndex { get; set; }

    public List<NotificationItem> Notifications { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        var notifications = HttpContext.Session.GetObject<List<NotificationItem>>("Notifications") ?? new List<NotificationItem>();

        // Load from API
        var response = await _httpClient.GetAsync($"https://localhost:7295/api/Orders/{Id}/Notification");
        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(jsonString);
            var root = doc.RootElement;

            var distributor = root.GetProperty("supplier").GetString();
            var totalAmount = root.GetProperty("totalPrice").GetDecimal();

            var quotationItems = new List<QuotationItem>();
            DateTime latestDeliveryDate = DateTime.MinValue;

            if (root.TryGetProperty("items", out var itemsElement))
            {
                foreach (var item in itemsElement.EnumerateArray())
                {
                    var deliveryDate = item.GetProperty("productDeliveryDate").GetDateTime();

                    quotationItems.Add(new QuotationItem
                    {
                        ProductId = item.GetProperty("productId").GetInt32(),
                        ProductName = item.GetProperty("productName").GetString(),
                        Quantity = item.GetProperty("quantity").GetInt32(),
                        UnitPrice = item.GetProperty("unitPrice").GetDecimal(),
                        ProductDeliveryDate = deliveryDate
                    });

                    if (deliveryDate > latestDeliveryDate)
                        latestDeliveryDate = deliveryDate;
                }
            }

            // Prevent Duplicate Notification Additions
            bool exists = notifications.Any(n =>
                n.Distributor == distributor &&
                n.TotalAmount == totalAmount &&
                n.QuotationItems.Count == quotationItems.Count &&
                n.DeliveryDate == latestDeliveryDate &&
                !n.QuotationItems.Except(quotationItems, new QuotationItemComparer()).Any()
            );

            if (!exists)
            {
                notifications.Add(new NotificationItem
                {
                    Distributor = distributor,
                    QuotationItems = quotationItems,
                    TotalAmount = totalAmount,
                    DeliveryDate = latestDeliveryDate
                });

                HttpContext.Session.SetObject("Notifications", notifications);
            }
        }

        Notifications = notifications;
        return Page();
    }

    public async Task<IActionResult> OnPostBuyNowAsync()
    {
        var notifications = HttpContext.Session.GetObject<List<NotificationItem>>("Notifications") ?? new List<NotificationItem>();

        if (NotificationIndex < 0 || NotificationIndex >= notifications.Count)
        {
            return new JsonResult(new { success = false });
        }

        var selectedNotification = notifications[NotificationIndex];

        var requestPayload = new
        {
            distributorName = selectedNotification.Distributor,
            items = selectedNotification.QuotationItems.Select(q => new
            {
                productId = q.ProductId,
                productName = q.ProductName,
                quantity = q.Quantity
            }).ToList()
        };

        var content = new StringContent(JsonSerializer.Serialize(requestPayload), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://localhost:7295/api/StockReduction/Reduce", content);

        if (response.IsSuccessStatusCode)
        {
            // Remove from Session after successful Buy
            notifications.RemoveAt(NotificationIndex);
            HttpContext.Session.SetObject("Notifications", notifications);

            return new JsonResult(new { success = true });
        }
        else
        {
            return new JsonResult(new { success = false });
        }
    }

    public IActionResult OnPostRemoveAsync()
    {
        var notifications = HttpContext.Session.GetObject<List<NotificationItem>>("Notifications") ?? new List<NotificationItem>();

        if (NotificationIndex < 0 || NotificationIndex >= notifications.Count)
        {
            return new JsonResult(new { success = false });
        }

        notifications.RemoveAt(NotificationIndex);
        HttpContext.Session.SetObject("Notifications", notifications);

        return new JsonResult(new { success = true });
    }
}

// --- QuotationItemComparer (Updated to include ProductDeliveryDate) ---
public class QuotationItemComparer : IEqualityComparer<QuotationItem>
{
    public bool Equals(QuotationItem x, QuotationItem y)
    {
        return x.ProductId == y.ProductId &&
               x.ProductName == y.ProductName &&
               x.Quantity == y.Quantity &&
               x.UnitPrice == y.UnitPrice &&
               x.ProductDeliveryDate == y.ProductDeliveryDate;
    }

    public int GetHashCode(QuotationItem obj)
    {
        return HashCode.Combine(obj.ProductId, obj.ProductName, obj.Quantity, obj.UnitPrice, obj.ProductDeliveryDate);
    }
}
