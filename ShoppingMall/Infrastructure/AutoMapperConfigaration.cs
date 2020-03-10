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
    }
}