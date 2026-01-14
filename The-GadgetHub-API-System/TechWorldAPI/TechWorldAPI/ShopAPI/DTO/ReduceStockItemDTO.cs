namespace TechWorldAPI.DTO
{
    public class ReduceStockItemDTO
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }

    public class ReduceStockRequestDTO
    {
        public List<ReduceStockItemDTO> Items { get; set; } = new();
    }
}
