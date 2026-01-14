using System.ComponentModel.DataAnnotations;

namespace ElectroComAPI.Models
{
    public class Quotation
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CustomerName { get; set; } = string.Empty;
        public List<QuotationItem> Items { get; set; } = new();
        public decimal TotalAmount { get; set; }
        public DateTime DeliveryDate { get; set; }
    }

}
