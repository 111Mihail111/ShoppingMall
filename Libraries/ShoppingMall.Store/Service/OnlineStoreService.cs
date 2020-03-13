using ShoppingMall.Store.Interface;
using ShoppingMall.Store.Models;
using System.Collections.Generic;

namespace ShoppingMall.Store.Service
{
    public class OnlineStoreService : IOnlineStore
    {
        private readonly StoreContext _storeContext;

        public OnlineStoreService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public void AddOnlineStore(OnlineStore onlineStore)
        {
            _storeContext.OnlineStores.Add(onlineStore);
            _storeContext.SaveChanges();
        }

        public void AddPhones(IEnumerable<PhoneStore> phoneStore)
        {
            _storeContext.PhoneStores.AddRange(phoneStore);
            _storeContext.SaveChanges();
        }

        public void AddEmails(IEnumerable<EmailStore> emailsStore)
        {
            _storeContext.EmailStores.AddRange(emailsStore);
            _storeContext.SaveChanges();
        }

        public void AddRegionalStoreData(IEnumerable<RegionalStoreData> regionalStoreData)
        {
            _storeContext.RegionalStoreData.AddRange(regionalStoreData);
            _storeContext.SaveChanges();
        }

        public void AddCategoriesOnlineStore(IEnumerable<CategoriesOnlineStore> categoriesOnlineStores)
        {
            _storeContext.CategoriesOnlineStores.AddRange(categoriesOnlineStores);
            _storeContext.SaveChanges();
        }

        public void AddPhonesOnlineStore(IEnumerable<PhonesOnlineStore> phoneOnlineStores)
        {
            _storeContext.PhoneOnlineStores.AddRange(phoneOnlineStores);
            _storeContext.SaveChanges();
        }

        public void AddEmailsOnlineStore(IEnumerable<EmailOnlineStore> emailsOnlineStore)
        {
            _storeContext.EmailOnlineStores.AddRange(emailsOnlineStore);
            _storeContext.SaveChanges();
        }
    }
}
