using System.Web.Optimization;

namespace ShoppingMall
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Scripts").Include(
                "~/Scripts/jquery-3.4.1.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/umd/popper.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/__сustom-Scripts.js"));

            bundles.Add(new StyleBundle("~/bundles/Styles").Include(
                "~/Content/bootstrap.min.css",
                "~/font-awesome-4.7.0/css/font-awesome.min.css",
                "~/Content/Style/__browser-style-reset.css",
                "~/Content/Style/__custom-style.css"));
        }
    }
}