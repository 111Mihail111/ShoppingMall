using System.Collections.Generic;

namespace ShoppingMall.Store.Models
{
    public class TypeCategoryStore
    {
        /// <summary>
        /// ID типа категории магизина
        /// </summary>
        public int TypeCategoryStoryId { get; set; }

        /// <summary>
        /// Наименование типа категории
        /// </summary>
        public string TypeCategoryName { get; set; }

        /// <summary>
        /// Лист категорий магазинов
        /// </summary>
        public List<CategoryStore> CategoryStores { get; set; }
    }
}
