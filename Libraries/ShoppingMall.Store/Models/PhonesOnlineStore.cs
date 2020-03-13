namespace ShoppingMall.Store.Models
{
    /// <summary>
    /// Модель составного ключа
    /// </summary>
    public class PhonesOnlineStore
    {
        /// <summary>
        /// Идентификатор магазина
        /// </summary>
        public int OnlineStoreId { get; set; }

        /// <summary>
        /// Идентификатор телефона
        /// </summary>
        public int PhoneStoreId { get; set; }
    }
}
