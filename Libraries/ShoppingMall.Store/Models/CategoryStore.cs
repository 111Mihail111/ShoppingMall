using System.Collections.Generic;

namespace ShoppingMall.Store.Models
{
    public class CategoryStore
    {
        /// <summary>
        /// ID категории магазина
        /// </summary>
        public int CategoryStoreId { get; set; }

        /// <summary>
        /// ID типа категории магазина
        /// </summary>
        public int TypeCategoryId { get; set; }

        /// <summary>
        /// Название категории
        /// </summary>
        public string CategoryName { get; set; }
    }
}
