namespace ShoppingMall.ViewModels.Shops
{
    /// <summary>
    /// Категории магазина VM
    /// </summary>
    public class CategoryStoreVM
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