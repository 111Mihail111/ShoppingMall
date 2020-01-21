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

        public List<TypeCategoryStore> GetCategoryStoreByName(string categoryName)
        {
            return _storeContext.TypeCategoryStores
                .Include(i => i.CategoryStores)
                .Where(w => w.CategoryStores.Any(a => a.CategoryName.StartsWith(categoryName) || a.CategoryName == "")).ToList();
        }
    }
}
