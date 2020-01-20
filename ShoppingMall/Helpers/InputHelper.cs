using ShoppingMall.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ShoppingMall.Helpers
{
    public static class InputHelper
    {
        public static MvcHtmlString CreateInput(this HtmlHelper htmlHelper, IEnumerable<StoreCategoryByTypesVM> storeCategoryByTypes)
        {
            TagBuilder input = new TagBuilder("input");
            input.AddCssClass("form-control");

            TagBuilder div = new TagBuilder("div");
            if (storeCategoryByTypes == null)
            {
                return MvcHtmlString.Create(input.ToString());
            }

            foreach (var item in storeCategoryByTypes)
            {
                div.InnerHtml = "<div>" + item.TypeCategoryName + "<div>";
            }

            return MvcHtmlString.Create(input.ToString());
        }
    }
}