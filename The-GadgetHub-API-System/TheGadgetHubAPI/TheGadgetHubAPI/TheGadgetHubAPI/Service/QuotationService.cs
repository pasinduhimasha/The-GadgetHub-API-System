using System.Text;
using System.Text.Json;
using TheGadgetHubAPI.DTO;

namespace TheGadgetHubAPI.Service
{
    public class QuotationService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public QuotationService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<QuotationResponseDto?> GetBestQuotationAsync(OrderRequestDto orderRequest)
        {
            // Only TechWorld for now
            var distributors = new List<(string Name, string Url)>
            {
                ("TechWorld", "https://localhost:7293/api/Quotation"),
                ("ElectroCom", "https://localhost:7292/api/Quotation"),
                ("GadgetCentral", "https://localhost:7294/api/Quotation")

            };

            var unavailableDistributors = new List<string>();

            var tasks = distributors.Select(async distributor =>
            {
                try
                {
                    var client = _httpClientFactory.CreateClient();

                    // Send product names directly
                    var mappedItems = orderRequest.Items
                        .Select(item => new OrderItemDto
                        {
                            ProductName = item.ProductName, // Send name
                            Quantity = item.Quantity
                        })
                        .ToList();

                    if (!mappedItems.Any())
                    {
                        Console.WriteLine($"No items in the order for distributor {distributor.Name}.");
                        return null;
                    }

                    var mappedOrderRequest = new OrderRequestDto
                    {
                        Items = mappedItems
                    };

                    var content = new StringContent(
                        JsonSerializer.Serialize(mappedOrderRequest),
                        Encoding.UTF8,
                        "application/json");

                    var response = await client.PostAsync(distributor.Url, content);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Failed to contact {distributor.Name}: {response.StatusCode}");
                        unavailableDistributors.Add(distributor.Name);
                        return null;
                    }

                    var json = await response.Content.ReadAsStringAsync();

                    var quote = JsonSerializer.Deserialize<QuotationResponseDto>(
                        json,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (quote != null)
                        quote.Supplier = distributor.Name;

                    Console.WriteLine($"Received Quotation from {distributor.Name}: {quote?.TotalPrice} LKR");

                    return quote;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error contacting {distributor.Name}: {ex.Message}");
                    unavailableDistributors.Add(distributor.Name);
                    return null;
                }
            });

            var quotations = await Task.WhenAll(tasks);

            var validQuotations = quotations.Where(q => q != null).ToList();

            if (!validQuotations.Any())
            {
                Console.WriteLine("All distributor services are currently unavailable:");
                foreach (var name in unavailableDistributors)
                    Console.WriteLine($" - {name}");
                return null;
            }

            // Pick the best quotation
            var bestQuote = validQuotations
                .OrderBy(q => q!.TotalPrice)
                .ThenBy(q => q.DeliveryDate)
                .First();

            Console.WriteLine($"Best Quotation Selected: {bestQuote.Supplier} for {bestQuote.TotalPrice} LKR");

            return bestQuote;
        }
    }
}
