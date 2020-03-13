namespace ShoppingMall.Store.Models
{
    /// <summary>
    /// Модель составного ключа
    /// </summary>
    public class EmailOnlineStore
    {
        /// <summary>
        /// Идентификатор онлайн магазина
        /// </summary>
        public int OnlineStoreId { get; set; }
        /// <summary>
        /// Идентификатор Электронного адреса магазина
        /// </summary>
        public int EmailStoreId { get; set; }
    }
}
