using AutoMapper;
using hedomi.application.DTOs.ArticleDTOs;
using hedomi.domain;

namespace hedomi.application.Mappings_Saber
{
    public class ArticleMappingProfile : Profile
    {
        public ArticleMappingProfile()
        {
            CreateMap<Article, ArticleDTO>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.BrandName : null))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null))
                .ForMember(dest => dest.StockQuantity, opt => opt.MapFrom(src => src.StockQuantity))
                .ForMember(dest => dest.SKU, opt => opt.MapFrom(src => src.SKU))
                .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.ImageUrls));

            CreateMap<CreateArticleDTO, Article>()
             .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.ImageUrls))
             .ForMember(dest => dest.SKU, opt => opt.MapFrom(src => src.SKU))
             .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
             .ForMember(dest => dest.BrandID, opt => opt.MapFrom(src => src.BrandID))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
             .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size))
             .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
             .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
             .ForMember(dest => dest.StockQuantity, opt => opt.MapFrom(src => src.StockQuantity))
             .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => src.CategoryID))
             .ForMember(dest => dest.Brand, opt => opt.Ignore())
             .ForMember(dest => dest.ArticleID, opt => opt.Ignore())
             .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<UpdateArticleDTO, Article>();
        }
    }
}
