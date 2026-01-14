using System.ComponentModel.DataAnnotations;
namespace TheGadgetHubAPI.DTO
{
    public class ProductWriteDTO
    {
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}
