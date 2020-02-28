using ShoppingMall.Store.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingMall.ViewModels
{
    public class OnlineStoreVM
    {
        /// <summary>
        /// ИД записи
        /// </summary>
        public int StoreId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "- Вы не указали ссылку на основной домен!")]
        [Display(Name = "UrlStore")]
        /// <summary>
        /// URL магазина
        /// </summary>
        public string UrlStore { get; set; }

        [Required (AllowEmptyStrings = false, ErrorMessage = "- Вы не указали название магазина!")]
        [RegularExpression(".{4,30}", ErrorMessage = "- Минимальная длинна названия - 4 символа. Максимальная - 30.")]
        /// <summary>
        /// Название магазина
        /// </summary>
        public string StoreName { get; set; }

        [Required(ErrorMessage = "- Вы не загрузили логотип!")]
        [Display(Name = "image")]
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
        public List<TypeCategoryStore> TypeCategoryStores { get; set; }

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
        public List<RegionalStoreData> RegionalStoreData { get; set; }
    }
}