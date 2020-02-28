using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingMall.Infrastructure;
using ShoppingMall.Store.Interface;
using ShoppingMall.Store.Models;
using ShoppingMall.ViewModels;

namespace ShoppingMall.Controllers
{
    public class ShopsController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly AutoMapperConfigaration _autoMapperConfigaration;

        public ShopsController(ICategoryService categoryService, AutoMapperConfigaration autoMapperConfigaration)
        {
            _categoryService = categoryService;
            _autoMapperConfigaration = autoMapperConfigaration;
        }

        [HttpGet]
        public ActionResult AddShops()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult GetOnlineStore(HttpPostedFileBase image, OnlineStoreVM onlineStoreVM)
        {
            if (!ModelState.IsValid)
            {
                return View("AddShopsErrorMessage", ModelState);
            }
            return PartialView();
        }

        [HttpPost]
        public JsonResult GetCategoryShopByName(string categoryName, List<int> categoryStoreId)
        {
            var config = _autoMapperConfigaration.Create<TypeCategoryStore, StoreCategoryByTypesVM>();
            var storeCategoryByTypesVM = 
                config.Map<IEnumerable<StoreCategoryByTypesVM>>(_categoryService.GetCategoryStoreByName(categoryName, categoryStoreId ?? new List<int>() { -1}));

            return Json(storeCategoryByTypesVM, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetImage(HttpPostedFileBase imageFile)
        {
            byte[] imageByte = null;
            using (var binaryReader = new BinaryReader(imageFile.InputStream))
            {
                imageByte = binaryReader.ReadBytes(imageFile.ContentLength);
            }

            return Json(Convert.ToBase64String(imageByte));
        }
    }
}