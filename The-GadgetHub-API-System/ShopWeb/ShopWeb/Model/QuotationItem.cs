namespace ShopWeb.Model
{
    public class QuotationItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;

        public DateTime ProductDeliveryDate { get; set; }
    }
}
