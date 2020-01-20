using ShoppingMall.Store.Models;
using System.Collections.Generic;

namespace ShoppingMall.Store.Interface
{
    public interface ICategoryService
    {
        List<TypeCategoryStore> GetCategoryStore();
    }
}
