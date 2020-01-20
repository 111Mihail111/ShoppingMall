using ShoppingMall.Store.Interface;
using ShoppingMall.Store.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ShoppingMall.Store.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly StoreContext _storeContext;

        public CategoryService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public List<TypeCategoryStore> GetCategoryStore()
        {
            return _storeContext.TypeCategoryStores.Include(x => x.CategoryStores).ToList();
        }
    }
}
