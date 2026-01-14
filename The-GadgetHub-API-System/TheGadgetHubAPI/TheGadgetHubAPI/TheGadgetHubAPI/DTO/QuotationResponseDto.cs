namespace TheGadgetHubAPI.DTO
{
    public class QuotationResponseDto
    {
        public string Supplier { get; set; } = string.Empty;
        public List<QuotationItemResponseDto> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(i => i.TotalPrice);

        public DateTime DeliveryDate { get; set; }
    }
}
