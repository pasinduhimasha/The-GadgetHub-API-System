using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GadgetCentralAPI.Models
{
    public class QuotaionItem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Quotation")]
        public int QuotationId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }


        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}
