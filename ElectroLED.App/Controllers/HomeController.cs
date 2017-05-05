namespace ElectroLED.app.Controllers
{
    using System.Web.Mvc;
    using Services;
    public class HomeController : Controller
    {
        private readonly HomeServices service;

        public HomeController()
        {
            this.service = new HomeServices();
        }

        public ActionResult Index()
        {
            var products = this.service.GetRecomendetProducts();
            return this.View(products);
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }

        public ActionResult NotFound(string message)
        {
            this.ViewBag.message = message;
            return this.View();
        }

    }
}