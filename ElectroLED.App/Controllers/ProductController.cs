namespace ElectroLED.App.Controllers
{
    using System.Web.Mvc;
    using app.Services;
    public class ProductController : Controller
    {
        private ProductServices service;

        public ProductController()
        {
            this.service = new ProductServices();
        }

        // GET: Product
        public ActionResult View(int productId)
        {
            if (!this.service.ValidateProduct(productId))
            {
                return this.RedirectToAction("NotFound", "Home", new { message = "The selected product is not valid" });
            }

            var product = this.service.GetProductDetails(productId);
            return this.View(product);
        }
    }
}