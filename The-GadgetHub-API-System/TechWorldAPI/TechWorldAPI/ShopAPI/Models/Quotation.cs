using System.ComponentModel.DataAnnotations;


namespace TechWorldAPI.Models
{
    public class Quotation
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CustomerName { get; set; } = string.Empty;

        public List<QuotaionItem> Items { get; set; } = new();
        public decimal TotalAmount { get; internal set; }

        public DateTime DeliveryDate { get; set; }
    }
}
