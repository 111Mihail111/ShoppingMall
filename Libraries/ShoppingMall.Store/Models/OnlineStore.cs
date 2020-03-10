using System.Collections.Generic;

namespace ShoppingMall.Store.Models
{
    /// <summary>
    /// Онлайн магазин
    /// </summary>
    public class OnlineStore
    {
        /// <summary>
        /// ИД записи
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// URL магазина
        /// </summary>
        public string UrlStore { get; set; }

        /// <summary>
        /// Название магазина
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// Логотип магазина
        /// </summary>
        public byte[] LogoStore { get; set; }

        /// <summary>
        /// Описание магазина
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Лист категорий магазина
        /// </summary>
        public List<CategoryStore> CategoryStorys { get; set; }

        /// <summary>
        /// Лист телефонов
        /// </summary>
        public List<PhoneStore> Phones { get; set; }

        /// <summary>
        /// Лист Email's
        /// </summary>
        public List<EmailStore> Emails { get; set; }

        /// <summary>
        /// Лист региональных данных магазина
        /// </summary>
        public List<RegionalStoreData> RegionalDateStores { get; set; }
    }
}
