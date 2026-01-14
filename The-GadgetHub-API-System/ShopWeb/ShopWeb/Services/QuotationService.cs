using ShopWeb.Model;

namespace ShopWeb.Services
{
    public class QuotationService
    {
        private readonly HttpClient _http;

        public QuotationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<QuotationResponse>> RequestQuotationsAsync(List<MyItem> products)
        {
            var response = await _http.PostAsJsonAsync("https://localhost:7295/api/Orders", new OrderRequest { Items = products });
            return await response.Content.ReadFromJsonAsync<List<QuotationResponse>>();
        }
    }
}
