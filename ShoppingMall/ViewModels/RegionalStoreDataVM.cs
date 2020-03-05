using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingMall.ViewModels
{
    public class RegionalStoreDataVM
    {
        /// <summary>
        /// Идентификатор региональных данных магазина
        /// </summary>
        public int RegionalDateStoreId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "- Вы не выбрали город!")]
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