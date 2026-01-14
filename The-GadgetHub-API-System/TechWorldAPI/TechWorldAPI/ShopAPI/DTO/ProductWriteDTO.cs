using System.ComponentModel.DataAnnotations;
namespace TechWorldAPI.DTO
{
    public class ProductWriteDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0.00, 9999999.99,
            ErrorMessage = "Price must be bigger than 0")]
        public decimal Price { get; set; }
        [Range(0, 10000000, ErrorMessage = "Stock quantity must be between 0 and 10,000,000.")]
        public int Stock { get; set; }
        public string Description { get; set; }

        public DateTime DeliveryDate { get; set; }

    }
}
