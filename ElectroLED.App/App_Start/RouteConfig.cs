namespace ElectroLED.App
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Errors-AdminPanel",
                url: "AdminPanel/Error/{id}",
                defaults: new { controller = "AdminPanel", action = "Error", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Groups",
                url: "Group/{action}/{id}",
                defaults: new { controller = "Group", action = "Select", id = 1 }
            );

            routes.MapRoute(
                name: "Category",
                url: "Category/{action}/{categoryId}",
                defaults: new { controller = "Category", action = "Products", categoryId = 1 }
            );

            routes.MapRoute(
                name: "Product",
                url: "Product/{action}/{productId}",
                defaults: new { controller = "Product", action = "View", productId = 1 }
            );

            routes.MapRoute(
                name: "Admin",
                url: "Admin/ProductsList/{page}",
                defaults: new { controller = "Admin", action = "Products", page = UrlParameter.Optional }
            );

        }
    }
}
