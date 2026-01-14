namespace GadgetCentralAPI.DTO
{
    public class ProductReadDTO
    {
        public int Id { get; set; }        
        public string Name { get; set; }        
        public decimal Price { get; set; }       
        public int Stock { get; set; }

        public DateTime DeliveryDate { get; set; }
        public string Description { get; set; }
    }
}
