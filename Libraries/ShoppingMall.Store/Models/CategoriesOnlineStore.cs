namespace ShoppingMall.Store.Models
{
    /// <summary>
    /// Модель составного ключа
    /// </summary>
    public class CategoriesOnlineStore
    {
        /// <summary>
        /// Идентификатор магазина
        /// </summary>
        public int OnlineStoreId { get; set; }

        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public int CategoryStoreId { get; set; }
    }
}
