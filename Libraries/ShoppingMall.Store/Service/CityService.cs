using ShoppingMall.Store.Interface;
using ShoppingMall.Store.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingMall.Store.Service
{
    public class CityService : ICity
    {
        private readonly StoreContext _storeContext;

        public CityService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IEnumerable<City> GetAllCities()
        {
            return _storeContext.Cities.ToList();
        }
    }
}
