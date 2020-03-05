using ShoppingMall.Store.Interface;
using ShoppingMall.Store.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

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

        public List<TypeCategoryStore> GetCategoryStoreByName(string categoryName, IEnumerable<int> categoryStoreId)
        {
            Expression<Func<CategoryStore, bool>> predicate = (item) => (item.CategoryName.ToLower().StartsWith(categoryName.ToLower()) || string.IsNullOrEmpty(categoryName)) && !categoryStoreId.Contains(item.CategoryStoreId);

            var typeEntities = _storeContext.TypeCategoryStores
                    .Include(i => i.CategoryStores)
                    .Where(w => w.CategoryStores.AsQueryable().Any(predicate))
                    .ToList();

            foreach (var item in typeEntities)
            {
                item.CategoryStores = item.CategoryStores.AsQueryable().Where(predicate).ToList();
            }

            return typeEntities;
        }

    }
}
