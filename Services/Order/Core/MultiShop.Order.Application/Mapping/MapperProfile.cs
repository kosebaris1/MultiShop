using AutoMapper;
using MultiShop.Order.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Results.AdressResults;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Features.Mediatr.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediatr.Results.OrderingResults;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile() {

            CreateMap<CreateAdressCommand, Adress>().ReverseMap();
            CreateMap<UpdateAdressCommand, Adress>().ReverseMap();
            CreateMap<RemoveAdressCommand, Adress>().ReverseMap();
            CreateMap<GetAdressByIdQueryResult, Adress>().ReverseMap();
            CreateMap<GetAdressQueryResult, Adress>().ReverseMap();


            CreateMap<CreateOrderDetailCommand, OrderDetail>().ReverseMap();
            CreateMap<UpdateOrderDetailCommand, OrderDetail>().ReverseMap();
            CreateMap<RemoveOrderDetailCommand, OrderDetail>().ReverseMap();
            CreateMap<GetOrderDetailByIdQueryResult, OrderDetail>().ReverseMap();
            CreateMap<GetAllOrderDetailQueryResult, OrderDetail>().ReverseMap();

            CreateMap<GetAllOrderingQueryResult, Ordering>().ReverseMap();
            CreateMap<GetOrderingByIdQueryResult, Ordering>().ReverseMap();
            CreateMap<CreateOrderingCommand, Ordering>().ReverseMap();
            CreateMap<UpdateOrderingCommand, Ordering>().ReverseMap();
            CreateMap<RemoveOrderingCommand, Ordering>().ReverseMap();
        }
    }
}
