namespace ElectroLED.App.Services
{
    using System;
    using System.Linq;
    using app.Services;
    using Enums;
    public class CategoryServices : Service
    {

        public int GetPages(int categoryId)
        {
            var productCount = this.GetProductsCount(categoryId);
            var producstPerCount = Convert.ToInt32(PageEnumerator.CategoryPageProducts);

            if (productCount > 0)
            {
                decimal doubleResult = (decimal)productCount / (decimal)producstPerCount;
                var result = (int)Math.Ceiling(doubleResult);
                return result;
            }

            return 0;
        }

        public string GetCategoryName(int categoryId)
        {
            var categoryName = this.Context.Categories.Where(category => category.Id == categoryId).Select(category=>category.Name).FirstOrDefault();
            return categoryName;
        }

        public bool ValidateCategory(int categoryId)
        {
            if (!this.Context.Categories.Any(category => category.Id == categoryId))
            {
                return false;
            }

            if (this.GetProductsCount(categoryId) <= 0)
            {
                return false;
            }

            return true;
        }

        public int GetProductsCount(int categoryId)
        {
            return this.Context
                .Products
                .Where(product=>product.IsActive)
                .Count(product => product.Category.Id == categoryId);
        }
    }
}