namespace ShopWeb.Model
{
    public class NotificationItem
    {
        public string Distributor { get; set; } = string.Empty;
        public List<QuotationItem> QuotationItems { get; set; } = new();
        public decimal TotalAmount { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
