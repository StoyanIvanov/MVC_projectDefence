namespace ElectroLED.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using app.Services;
    using Models.ViewModels;

    public class APIServices : Service
    {
        public ICollection<SortingRulesViewModel> GetSortingRulesViewModel()
        {
            var rules = this.Context
                .SortingRules
                .OrderBy(rule => rule.RuleSorting)
                .Select(rule => new SortingRulesViewModel
                {
                    Id = rule.Id,
                    Name = rule.Name,
                })
                .ToList();

            return rules;
        }

        public void AddProductReview(int productId)
        {
            var entity =
                this.Context.Products
                .Where(product => product.IsActive)
                .FirstOrDefault(product => product.Id == productId);

            if (entity != null)
            {
                entity.PreviewCount = entity.PreviewCount + 1;
                this.Context.SaveChanges();
            }
        }
    }
}