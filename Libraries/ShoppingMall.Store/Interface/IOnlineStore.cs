using ShoppingMall.Store.Models;
using System.Collections.Generic;

namespace ShoppingMall.Store.Interface
{
    public interface IOnlineStore
    {
        /// <summary>
        /// Добавление онлайн магазина
        /// </summary>
        /// <param name="onlineStore">Модель магазина</param>
        void AddOnlineStore(OnlineStore onlineStore);
        /// <summary>
        /// Добавление телефонов
        /// </summary>
        /// <param name="phonesStore">Перечесление моделей</param>
        void AddPhones(IEnumerable<PhoneStore> phonesStore);
        /// <summary>
        /// Добавление категорий онлайн магазина
        /// </summary>
        /// <param name="categoriesOnlineStores">Составная модель категорий онлайн магазина</param>
        void AddCategoriesOnlineStore(IEnumerable<CategoriesOnlineStore> categoriesOnlineStores);
        /// <summary>
        /// Добавление телефонов онлайн магазина
        /// </summary>
        /// <param name="phonesOnlineStore">Составная модель телефонов онлайн магазина</param>
        void AddPhonesOnlineStore(IEnumerable<PhonesOnlineStore> phonesOnlineStore);
        /// <summary>
        /// Добавление электронных адресов
        /// </summary>
        /// <param name="emailsStore">Модель электронных адресов</param>
        void AddEmails(IEnumerable<EmailStore> emailsStore);
        /// <summary>
        /// Добавление электронных адресов онлайн магазина
        /// </summary>
        /// <param name="emailsOnlineStore">Составная модель электронных адресов онлайн магазина</param>
        void AddEmailsOnlineStore(IEnumerable<EmailOnlineStore> emailsOnlineStore);
        /// <summary>
        /// Добавление региональных данных магазина
        /// </summary>
        /// <param name="regionalStoreData">Модель региональных данных</param>
        void AddRegionalStoreData(IEnumerable<RegionalStoreData> regionalStoreData);
    }
}
