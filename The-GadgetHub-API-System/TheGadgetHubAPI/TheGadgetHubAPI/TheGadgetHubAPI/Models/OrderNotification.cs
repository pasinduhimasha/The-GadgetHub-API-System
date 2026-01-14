using TheGadgetHubAPI.DTO;

namespace TheGadgetHubAPI.Models
{
    public class OrderNotification
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Supplier { get; set; } = string.Empty;
        public List<QuotationItemResponseDto> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(i => i.TotalPrice);
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime DeliveryDate { get; set; }


    }
}
