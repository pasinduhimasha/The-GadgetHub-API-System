namespace ShopWeb.Model
{
    public class QuotationResponse
    {
        public List<QuotationItem> Items { get; set; } = new();
        public decimal TotalAmount { get; set; }
    }
}
