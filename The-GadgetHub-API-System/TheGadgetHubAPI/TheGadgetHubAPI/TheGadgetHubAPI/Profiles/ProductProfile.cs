using AutoMapper;
using TheGadgetHubAPI.Models;
using TheGadgetHubAPI.DTO;
namespace TheGadgetHubAPI.Profiles
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
