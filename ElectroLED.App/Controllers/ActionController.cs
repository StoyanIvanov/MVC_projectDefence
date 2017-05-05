namespace ElectroLED.App.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Http;
    using Enums;
    using Services;
    using Models;
    using Models.ViewModels;
    using Newtonsoft.Json.Linq;

    public class ActionController : ApiController
    {
        private APIServices service;

        public ActionController()
        {
            this.service = new APIServices();
        }

        [HttpGet]
        [ActionName("Groups")]
        public ICollection<GroupViewModel> GetGroupsViewModels()
        {
            var groups = this.service.GetGroupsViewModel();
            return groups;
        }

        [HttpGet]
        [ActionName("SortingRules")]
        public ICollection<SortingRulesViewModel> GetSortingRulesViewModels()
        {
            var rules = this.service.GetSortingRulesViewModel();
            return rules;
        }

        [HttpPost]
        [ActionName("Products")]
        public ICollection<ProductViewModel> GetCategroyProducts(JObject jsonData)
        {
            dynamic json = jsonData;
            int page = 0;
            int categoryId = 0;
            if (!int.TryParse(json.page.ToString(), out page) || page == 0)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            if (!int.TryParse(json.categoryId.ToString(), out categoryId) || categoryId == 0)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            string sortingRule = json.sorting.ToString();

            var products = this.service.GetProductsViewModel(PageEnumerator.CategoryPageProducts, page, sortingRule, new Category() { Id = categoryId });

            if (products == null)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return products;
        }

        [HttpPost]
        [ActionName("ProductView")]
        public ICollection<ProductViewModel> AddProductViewAndGetRecomendetProducts(JObject jsonData)
        {
            dynamic json = jsonData;
            int productId = 0;

            if (!int.TryParse(json.Id.ToString(), out productId) || productId <= 0)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            if (!this.service.ValidateProduct(productId))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            this.service.AddProductReview(productId);
            var products = this.service.GetProductsViewModel(4, true, productId);

            if (products==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return products;
        }

        [HttpPost]
        [ActionName("DeleteProduct")]
        [Authorize(Roles = "Administrator")]
        public ICollection<ProductViewModel> DeleteProduct(JObject jsonData)
        {
            dynamic json = jsonData;
            int productId = 0;

            if (!int.TryParse(json.Id.ToString(), out productId) || productId <= 0)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            if (!this.service.ValidateProduct(productId))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            this.service.AddProductReview(productId);
            var products = this.service.GetProductsViewModel(4, true, productId);

            if (products == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return products;
        }

    }
}

