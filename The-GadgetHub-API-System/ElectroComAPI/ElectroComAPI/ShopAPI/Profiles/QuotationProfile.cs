using AutoMapper;
using ElectroComAPI.DTO;
using ElectroComAPI.Models;

namespace ElectroComAPI.Profiles
{
    public class QuotationProfile : Profile
    {
        public QuotationProfile()
        {
            CreateMap<QuotationCreateDTO, Quotation>();
            CreateMap<QuotationItemDto, QuotationItem>();

            CreateMap<Quotation, QuotationResponseDto>();
            CreateMap<QuotationItem, QuotationItemDetailDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}