namespace TheGadgetHubAPI.DTO
{
    public class OrderItemDto
    {
        

        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderRequestDto
    {
        public List<OrderItemDto> Items { get; set; } = new();
    }
}
