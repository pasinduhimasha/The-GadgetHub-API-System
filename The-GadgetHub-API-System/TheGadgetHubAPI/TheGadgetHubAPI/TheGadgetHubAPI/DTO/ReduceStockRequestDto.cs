namespace TheGadgetHubAPI.DTO
{
    public class ReduceStockRequestDto
    {
        public string DistributorName { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}
