using AutoMapper;
using TechWorldAPI.Models;
using TechWorldAPI.DTO;
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
