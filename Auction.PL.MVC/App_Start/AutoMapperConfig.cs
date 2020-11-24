using Auction.Entities;
using Auction.PL.MVC.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.PL.MVC.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Config { get; private set; }

        public static void RegisterMaps()
        {
            Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, DisplayUserVM>();
                cfg.CreateMap<User, CreateUserVM>();
                cfg.CreateMap<CreateUserVM, User>()
                    .ForMember(dest => dest.PlacedLots, src => src.Ignore())
                    .ForMember(dest => dest.Id, src => src.Ignore())
                    .ForMember(dest => dest.PurchasedLots, src => src.Ignore());                    

                cfg.CreateMap<Lot, CreateLotVM>();
                cfg.CreateMap<Lot, DisplayLotVM>();
                cfg.CreateMap<CreateLotVM, Lot>()
                    .ForMember(dest => dest.Buyer, src => src.Ignore())
                    .ForMember(dest => dest.Seller, src => src.Ignore())
                    .ForMember(dest => dest.Id, src => src.Ignore())
                    .ForMember(dest => dest.IdBuyer, src => src.Ignore());
            });
            Config.AssertConfigurationIsValid();
        }

    }
}