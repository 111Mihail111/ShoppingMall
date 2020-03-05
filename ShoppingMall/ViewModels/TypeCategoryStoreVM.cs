using ShoppingMall.Store.Models;
using System.Collections.Generic;

namespace ShoppingMall.ViewModels
{
    public class TypeCategoryStoreVM
    {
        /// <summary>
        /// Лист категорий магазинов
        /// </summary>
        public List<CategoryStoreVM> CategoryStores { get; set; }

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