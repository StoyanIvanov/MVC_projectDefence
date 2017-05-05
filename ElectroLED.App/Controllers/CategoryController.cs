namespace ElectroLED.App.Controllers
{
    using System.Web.Mvc;
    using Enums;
    using Services;
    public class CategoryController : Controller
    {
        private CategoryServices service;

        public CategoryController()
        {
            this.service = new CategoryServices();
        }
        // GET: Category
        [HttpGet]
        public ActionResult Products(int categoryId)
        {

            if (!this.service.ValidateCategory(categoryId))
            {
                return this.RedirectToAction("NotFound", "Home", new { message = "The selected category not have a products" });
            }

            var pages = this.service.GetPages(categoryId);
            var productsCount = this.service.GetProductsCount(categoryId);
            var categoryName = this.service.GetCategoryName(categoryId);
            var productsPerPage = (int) PageEnumerator.CategoryPageProducts;

            this.ViewBag.Pages = pages;
            this.ViewBag.ProductsCount = productsCount;
            this.ViewBag.CategoryName = categoryName;
            this.ViewBag.ProductsPerPage = productsPerPage;
            this.ViewBag.categoryID = categoryId;
            return this.View();
        }

    }
}