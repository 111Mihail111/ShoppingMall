using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingMall.ViewModels.Shops
{
    /// <summary>
    /// Региональные данные магазина VM
    /// </summary>
    public class RegionalStoreDataVM
    {
        /// <summary>
        /// Город
        /// </summary>
        public CityVM City { get; set; }

        /// <summary>
        /// Региональный поддомен
        /// </summary>
        public string RegionalSubdomain { get; set; }

        /// <summary>
        /// Лист региональный адресов
        /// </summary>
        public List<AddressVM> Addresses { get; set; }

        /// <summary>
        /// Лист телефонов магазина
        /// </summary>
        public List<PhoneStoreVM> PhoneStores { get; set; }

        /// <summary>
        /// Лист Email'ов магазина
        /// </summary>
        public List<EmailStoreVM> EmailStores { get; set; }
    }
}