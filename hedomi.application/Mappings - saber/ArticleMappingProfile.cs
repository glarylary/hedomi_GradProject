using AutoMapper;
using hedomi.application.DTOs.ArticleDTOs;
using hedomi.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.Mappings_Saber
{
    public class ArticleMappingProfile : Profile
    {
        public ArticleMappingProfile()
        {
            CreateMap<Article, ArticleDTO>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.StockQuantity, opt => opt.MapFrom(src => src.StockQuantity))
                .ForMember(dest => dest.SKU, opt => opt.MapFrom(src => src.SKU));

            CreateMap<CreateArticleDTO, Article>();
            CreateMap<UpdateArticleDTO, Article>();
        }

    }
}
