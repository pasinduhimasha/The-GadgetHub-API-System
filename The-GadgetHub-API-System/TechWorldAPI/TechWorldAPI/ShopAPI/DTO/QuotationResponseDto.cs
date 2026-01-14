namespace TechWorldAPI.DTO
{
    public class QuotationResponseDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal TotalAmount { get; set; }

        public DateTime DeliveryDate { get; set; }

        public List<QuotationItemDetailDto> Items { get; set; }
    }

    public class QuotationItemDetailDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public DateTime ProductDeliveryDate { get; set; }

        public decimal TotalPrice { get; set; }
    }
}