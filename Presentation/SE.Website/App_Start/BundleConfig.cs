using System.Web.Optimization;

namespace SE.Website.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterStyleBundles(bundles);
            RegisterJavascriptBundles(bundles);
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css")
                            .Include("~/Content/jquery.loadmask.css")
                            .Include("~/Content/site.css")
                            .Include("~/Content/mycss/*.css")
                            );
        }

        private static void RegisterJavascriptBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js")
                            .Include("~/Scripts/jquery.validate.js")
                            .Include("~/Scripts/fromwangying/*.js")
                            .Include("~/Scripts/Extension/*.js")
                            .Include("~/Scripts/jquery.loadmask.js")
                            .Include("~/Scripts/webExpress/webExpress.js")
                            .Include("~/Scripts/webExpress/webExpress.utility.js")
                            .Include("~/Scripts/webExpress/webExpress.utility.ajax.js")
                            .Include("~/Scripts/common/*.js")
                            .Include("~/Scripts/views/base/*.js")
                            );
        }
    }
}