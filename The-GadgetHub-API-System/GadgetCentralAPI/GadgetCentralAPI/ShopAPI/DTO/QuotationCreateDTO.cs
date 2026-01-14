namespace GadgetCentralAPI.DTO
{
    public class QuotationCreateDTO
    {
        public string CustomerName { get; set; } = string.Empty;
        public List<QuotationItemDto> Items { get; set; } = new();
    }

    public class QuotationItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

