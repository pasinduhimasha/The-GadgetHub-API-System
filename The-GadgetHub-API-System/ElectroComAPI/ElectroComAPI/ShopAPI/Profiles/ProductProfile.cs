using AutoMapper;
using ElectroComAPI.Models;
using ElectroComAPI.DTO;
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
