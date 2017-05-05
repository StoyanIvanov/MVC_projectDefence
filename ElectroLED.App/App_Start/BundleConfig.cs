namespace ElectroLED.App
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.11.0.min.js",
                        "~/Scripts/jquery.cookie.js",
                        "~/Scripts/jquery.flexslider.min.js",
                        "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/respond").Include(
                "~/Scripts/respond.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap-hover-dropdown.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                      "~/Scripts/owl.carousel.min.js",
                      "~/Scripts/front.js",
                      "~/Scripts/waypoints.min.js",
                      "~/Scripts/jquery.unobtrusive-ajax.min.js"
                      ));

            bundles.Add(new StyleBundle("~/content/appcss").Include(
                "~/Content/css/font-awesome.css",
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/animate.min.css",
                "~/Content/css/owl.carousel.css",
                "~/Content/css/owl.theme.css",
                "~/Content/css/style.default.css",
                "~/Content/css/custom.css"
                      ));
        }
    }
}
