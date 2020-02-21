using System.Collections.Generic;

namespace ShoppingMall.Store.Models
{
    public class RegionalStoreData
    {
        /// <summary>
        /// Идентификатор региональных данных магазина
        /// </summary>
        public int RegionalDateStoreId { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Региональный поддомен
        /// </summary>
        public string RegionalSubdomain { get; set; }

        /// <summary>
        /// Лист региональный адресов
        /// </summary>
        public List<Address> Addresses { get; set; }

        /// <summary>
        /// Лист телефонов магазина
        /// </summary>
        public List<PhoneStore> PhoneStores { get; set; }

        /// <summary>
        /// Лист Email'ов магазина
        /// </summary>
        public List<EmailStore> EmailStores { get; set; }
    }
}
