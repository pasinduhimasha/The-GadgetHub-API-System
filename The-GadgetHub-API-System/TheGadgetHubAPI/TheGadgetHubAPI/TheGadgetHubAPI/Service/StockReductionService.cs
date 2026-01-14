using System.Text;
using System.Text.Json;
using TheGadgetHubAPI.DTO;

namespace TheGadgetHubAPI.Service
{
    public class StockReductionService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StockReductionService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> ReduceStockAsync(string distributorName, List<OrderItemDto> items)
        {
            var distributors = new Dictionary<string, string>
            {
                { "TechWorld", "https://localhost:7293/api/Product/ReduceStock" },
                { "ElectroCom", "https://localhost:7292/api/Product/ReduceStock" },
                { "GadgetCentral", "https://localhost:7294/api/Product/ReduceStock" }
            };

            if (!distributors.TryGetValue(distributorName, out var url))
            {
                Console.WriteLine($"Distributor URL not found for: {distributorName}");
                return false;
            }

            var request = new
            {
                Items = items.Select(i => new
                {
                    ProductName = i.ProductName,
                    Quantity = i.Quantity
                }).ToList()
            };

            var client = _httpClientFactory.CreateClient();

            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to reduce stock at {distributorName}: {response.StatusCode} - {error}");
                return false;
            }

            Console.WriteLine($"Stock reduced successfully at {distributorName}.");
            return true;
        }
    }
}
