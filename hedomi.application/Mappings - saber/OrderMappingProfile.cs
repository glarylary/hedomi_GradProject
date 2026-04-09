using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hedomi.domain;
using hedomi.application.DTOs.OrderDTOs;

namespace hedomi.application.Mappings___saber
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
            CreateMap<CreateOrderDTO, Order>();

            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<CreateOrderItemDTO, OrderItem>();
        }
    }
}
