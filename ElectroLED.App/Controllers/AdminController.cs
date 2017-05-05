using ElectroLED.App.Services;

namespace ElectroLED.App.Controllers
{
    using System.Web.Mvc;
    using app.Services;
    using Enums;

    [Authorize]
    public class AdminController : Controller
    {
        private readonly AdminServices service;

        public AdminController()
        {
            this.service = new AdminServices();
        }

        // GET: AdminPanel/Products/{int}
        [Authorize]
        public ActionResult ProductsList(int? page)
        {
            if (!this.User.IsInRole("Employee") || !this.User.IsInRole("Administrator"))
            {
                return this.RedirectToAction("Index", "Home");
            }

            int selectPage = 1;
            if (page != null && (int)page > 0)
            {
                selectPage = (int) page;
            }

            var pages = this.service.GetProductPagesCount(PageEnumerator.AdminProductListingPage);
            var products = this.service.GetProductsAdminViewModel(PageEnumerator.AdminProductListingPage, selectPage);

            if (products == null)
            {
                return this.RedirectToAction("Error", "Admin", 1);
            }

            this.ViewBag.Pages = pages;
            this.ViewBag.Page = page;
            this.ViewBag.IsAdmin = this.User.IsInRole("Administrator");
            return this.View(products);
        }

        // GET: AdminPanel/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            if (!this.User.IsInRole("Employee") || !this.User.IsInRole("Administrator"))
            {
                return this.RedirectToAction("Index", "Home");
            }

            //TODO validations
            return this.View();
        }

        [HttpGet]
        public ActionResult Error(int id)
        {
            //TODO validations
            var error = this.service.GetErrorMessage(id);
            return this.View(error);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            if (!this.User.IsInRole("Employee") || !this.User.IsInRole("Administrator"))
            {
                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int productId)
        {
            //Redirect if the user is no
            if (!this.User.IsInRole("Employee") || !this.User.IsInRole("Administrator"))
            {
                return this.RedirectToAction("Index", "Home");
            }

            //TODO validations
            return this.View();
        }

    }
}