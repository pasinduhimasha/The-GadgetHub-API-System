using AutoMapper;
using TechWorldAPI.DTO;
using TechWorldAPI.Models;

namespace GadgetCentralAPI.Profiles
{
    public class QuotationProfile : Profile
    {
        public QuotationProfile()
        {
            CreateMap<QuotationCreateDTO, Quotation>();
            CreateMap<QuotationItemDto, QuotaionItem>();

            CreateMap<Quotation, QuotationResponseDto>();
            CreateMap<QuotaionItem, QuotationItemDetailDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}