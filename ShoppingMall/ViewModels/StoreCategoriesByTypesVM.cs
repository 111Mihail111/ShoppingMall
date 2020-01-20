using ShoppingMall.Store.Models;
using System.Collections.Generic;

namespace ShoppingMall.ViewModels
{
    public class StoreCategoryByTypesVM
    {
        /// <summary>
        /// Лист категорий магазинов
        /// </summary>
        public List<CategoryStore> CategoryStores { get; set; }

        /// <summary>
        /// Наименование типа категории
        /// </summary>
        public string TypeCategoryName { get; set; }

        /// <summary>
        /// ИД типа категории
        /// </summary>
        public int TypeCategoryStoryId { get; set; }
    }
}