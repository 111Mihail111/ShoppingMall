using AutoMapper;
using ShoppingMall.Store.Models;
using ShoppingMall.ViewModels.Shops;

namespace ShoppingMall.Infrastructure
{
    public class AutoMapperConfigaration
    {
        public IMapper Create<G, F>()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<G, F>()).CreateMapper();
        }

        public IMapper TypeCategoryMapper()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TypeCategoryStore, TypeCategoryStoreVM>();
                cfg.CreateMap<CategoryStore, CategoryStoreVM>();
            }).CreateMapper();

            return mapper;
        }

        public IMapper OnlineStoreMapper()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OnlineStoreVM, OnlineStore>()
                .ForMember(fm => fm.LogoStore, src => src.Ignore())
                .ForMember(fm => fm.LogoStore, src => src.MapFrom(mf => mf.LogoStoreByte))
                .ForMember(fm => fm.StoreId, src => src.Ignore());

                cfg.CreateMap<CategoryStoreVM, CategoryStore>();
                cfg.CreateMap<PhoneStoreVM, PhoneStore>();

                cfg.CreateMap<RegionalStoreDataVM, RegionalStoreData>()
                .ForMember(fm => fm.RegionalDateStoreId, src => src.Ignore());

                cfg.CreateMap<CityVM, City>()
                .ForMember(fm => fm.Id, src => src.Ignore())
                .ForMember(fm => fm.RegionId, src => src.Ignore());

                cfg.CreateMap<AddressVM, Address>()
                .ForMember(fm => fm.AddressId, src => src.Ignore());

                cfg.CreateMap<PhoneStoreVM, PhoneStore>()
                .ForMember(fm => fm.PhoneStoreId, src => src.Ignore());

                cfg.CreateMap<EmailStoreVM, EmailStore>()
                .ForMember(fm => fm.Id, src => src.Ignore())
                .ForMember(fm => fm.Name, src => src.MapFrom(mf => mf.Email));

            }).CreateMapper();

            return mapper;
        }

        public IMapper RegionalStoreDataMapper()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegionalStoreDataVM, RegionalStoreData>()
                .ForMember(fm => fm.RegionalDateStoreId, src => src.Ignore());

                cfg.CreateMap<CityVM, City>()
                .ForMember(fm => fm.Id, src => src.Ignore())
                .ForMember(fm => fm.RegionId, src => src.Ignore());

                cfg.CreateMap<AddressVM, Address>()
                .ForMember(fm => fm.AddressId, src => src.Ignore());

                cfg.CreateMap<PhoneStoreVM, PhoneStore>()
                .ForMember(fm => fm.PhoneStoreId, src => src.Ignore());

                cfg.CreateMap<EmailStoreVM, EmailStore>()
                .ForMember(fm => fm.Id, src => src.Ignore())
                .ForMember(fm => fm.Name, src => src.MapFrom(mf => mf.Email));

            }).CreateMapper();

            return mapper;
        }
    }
}