using AutoMapper;

namespace ShoppingMall.Infrastructure
{
    public class AutoMapperConfigaration
    {
        public IMapper Create<G, F>()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<G, F>()).CreateMapper();
        }
    }
}