using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using ShoppingMall.Infrastructure;
using ShoppingMall.Store.Interface;
using ShoppingMall.Store.Models;
using ShoppingMall.ViewModels.Shops;

namespace ShoppingMall.Controllers
{
    public class ShopsController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICity _city;
        private readonly IOnlineStore _onlineStore;
        private readonly AutoMapperConfigaration _autoMapperConfigaration;

        public ShopsController(ICategoryService categoryService, ICity city, IOnlineStore onlineStore, AutoMapperConfigaration autoMapperConfigaration)
        {
            _categoryService = categoryService;
            _city = city;
            _onlineStore = onlineStore;
            _autoMapperConfigaration = autoMapperConfigaration;
        }

        [HttpGet]
        public ActionResult AddShops()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult GetOnlineStore(OnlineStoreVM onlineStoreVM)
        {
            if (!ModelState.IsValid)
            {
                return View("AddShopsErrorMessage", ModelState);
            }

            onlineStoreVM.LogoStoreByte = GetByteImage(onlineStoreVM.LogoStore);

            var config = _autoMapperConfigaration.OnlineStoreMapper();
            var onlineStore = config.Map<OnlineStore>(onlineStoreVM);

            var a = _autoMapperConfigaration.RegionalStoreDataMapper();
            var b = a.Map<RegionalStoreData>(onlineStoreVM.RegionalStoreData);

            _onlineStore.AddOnlineStore(onlineStore);
            _onlineStore.AddPhones(onlineStore.Phones);
            _onlineStore.AddEmails(onlineStore.Emails);
            _onlineStore.AddRegionalStoreData(onlineStore.RegionalDateStores);

            CreateModelByCategoryOnlineStore(onlineStore, onlineStore.StoreId);
            CreateModelByPhoneOnlineStore(onlineStore, onlineStore.StoreId);
            CreateModelByEmailOnlineStore(onlineStore, onlineStore.StoreId);

            return PartialView();
        }

        public void CreateModelByEmailOnlineStore(OnlineStore onlineStore, int onlineStoreId)
        {
            List<EmailOnlineStore> emailOnlineStores = new List<EmailOnlineStore>();
            foreach (var item in onlineStore.Phones)
            {
                EmailOnlineStore emailOnlinestore = new EmailOnlineStore
                {
                    OnlineStoreId = onlineStoreId,
                    EmailStoreId = item.PhoneStoreId
                };
                emailOnlineStores.Add(emailOnlinestore);
            }

            _onlineStore.AddEmailsOnlineStore(emailOnlineStores);
        }

        public void CreateModelByPhoneOnlineStore(OnlineStore onlineStore, int onlineStoreId)
        {
            List<PhonesOnlineStore> phonesStore = new List<PhonesOnlineStore>();
            foreach (var item in onlineStore.Phones)
            {
                PhonesOnlineStore phoneOnlineStore = new PhonesOnlineStore
                {
                    OnlineStoreId = onlineStoreId, PhoneStoreId = item.PhoneStoreId
                };
                phonesStore.Add(phoneOnlineStore);
            }

            _onlineStore.AddPhonesOnlineStore(phonesStore);
        }

        public void CreateModelByCategoryOnlineStore(OnlineStore onlineStore, int onlineStoreId)
        {
            List<CategoriesOnlineStore> categoriesOnlineStores = new List<CategoriesOnlineStore>();
            foreach (var item in onlineStore.CategoryStores)
            {
                CategoriesOnlineStore categoriesOnlineStore = new CategoriesOnlineStore 
                { 
                    OnlineStoreId = onlineStoreId, CategoryStoreId = item.CategoryStoreId 
                };
                categoriesOnlineStores.Add(categoriesOnlineStore);
            }

            _onlineStore.AddCategoriesOnlineStore(categoriesOnlineStores);
        }

        [HttpPost]
        public JsonResult GetCategoryShopByName(string categoryName, List<int> categoryStoreId)
        {
            var config = _autoMapperConfigaration.TypeCategoryMapper();
            var storeCategoryByTypesVM =
                config.Map<IEnumerable<TypeCategoryStoreVM>>(_categoryService.GetCategoryStoreByName(categoryName, categoryStoreId ?? new List<int>() { -1 }));

            return Json(storeCategoryByTypesVM, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetImage(HttpPostedFileBase imageFile)
        {
            return Json(Convert.ToBase64String(GetByteImage(imageFile)));
        }

        private static byte[] GetByteImage(HttpPostedFileBase imageFile)
        {
            byte[] imageByte = null;
            using (var binaryReader = new BinaryReader(imageFile.InputStream))
            {
                imageByte = binaryReader.ReadBytes(imageFile.ContentLength);
            }

            return imageByte;
        }

        [HttpPost]
        public JsonResult GetCities()
        {
            var config = _autoMapperConfigaration.Create<City, CityVM>();
            var cities = config.Map<IEnumerable<CityVM>>(_city.GetAllCities());

            return Json(cities, JsonRequestBehavior.AllowGet);
        }
    }
}