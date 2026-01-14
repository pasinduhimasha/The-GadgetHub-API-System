using AutoMapper;
using GadgetCentralAPI.Models;
using GadgetCentralAPI.DTO;
namespace ShopAPI.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductReadDTO>();
            CreateMap<ProductWriteDTO, Product>();
        }
    }
}
