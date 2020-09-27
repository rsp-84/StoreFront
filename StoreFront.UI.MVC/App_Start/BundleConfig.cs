using System.Web.Optimization;

namespace StoreFront.UI.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/content/vendor/jquery/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                      "~/content/vendor/nouislider/nouislider.min.js",
                      "~/content/vendor/bootstrap-select/js/bootstrap-select.min.js",
                      "~/content/vendor/owl.carousel2/owl.carousel.min.js",
                      "~/content/vendor/owl.carousel2.thumbs/owl.carousel2.thumbs.min.js",
                      "~/content/js/front.js",
                      "~/content/js/selectedNavigation.js"
                      ));

            bundles.Add(new StyleBundle("~/bundles/Content/css").Include(
                      "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/vendor/nouislider/nouislider.min.css",
                      "~/Content/vendor/bootstrap-select/css/bootstrap-select.min.css",
                      "~/Content/vendor/owl.carousel2/assets/owl.carousel.min.css",
                      "~/Content/vendor/owl.carousel2/assets/owl.theme.default.css",
                      "~/Content/css/style.default.css",
                      "~/Content/css/custom.css"
                      ));
        }
    }
}
