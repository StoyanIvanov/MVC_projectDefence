namespace ElectroLED.app.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using App.Enums;
    using Data;
    using Models;
    using Models.ViewModels;

    public abstract class Service
    {
        protected Service()
        {
            this.Context = new ElectroLEDContext();
        }

        protected ElectroLEDContext Context { get; set; }

        public ICollection<ProductViewModel> GetProductsViewModel(PageEnumerator pageType, int page, string sorting, Group group)
        {
            var pageCount = Convert.ToInt32(pageType);
            var sortRule = this.Context.SortingRules.FirstOrDefault(sort => sort.Name == sorting);
            page -= 1;

            if (sortRule == null || page < 0)
            {
                return null;
            }

            var products = this.Context
                .Products
                .Where(product => product.Category.Group.Id == group.Id && product.IsActive)
                .Select(product => new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = "€ " + product.Prices.FirstOrDefault(price => price.Currency.IsoCode == "EUR").Value,
                    DefaultImageName = product.Images
                                              .FirstOrDefault(image => image.isDefault == true)
                                              .File
                })
                .ToList();

            return products
                   .OrderBy(sortRule.ProductSortParameter + " " + sortRule.SortingType)
                   .OrderBy(product => product.CategorySortingRule)
                   .Skip(page * pageCount)
                   .Take(pageCount)
                   .ToList();
        }

        public ICollection<ProductViewModel> GetProductsViewModel(PageEnumerator pageType, int page, string sorting, Category category)
        {
            var pageCount = Convert.ToInt32(pageType);
            var sortRule = this.Context.SortingRules.FirstOrDefault(sort => sort.Name == sorting);

            page = page - 1;

            if (sortRule == null || page < 0)
            {
                return null;
            }

            var products = this.Context
                .Products
                .Where(product => product.Category.Id == category.Id && product.IsActive)
                .Select(product => new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = "€ " + product.Prices.FirstOrDefault(price => price.Currency.IsoCode == "EUR").Value,
                    CategorySortingRule = product.Category.SortingRule,
                    DefaultImageName = product.Images
                                              .FirstOrDefault(image => image.isDefault == true)
                                              .File

                })
                .ToList();

            return products
                   .OrderBy(sortRule.ProductSortParameter + " " + sortRule.SortingType)
                   .OrderBy(product => product.CategorySortingRule)
                   .Skip(page * pageCount)
                   .Take(pageCount)
                   .ToList();

        }

        public ICollection<ProductViewModel> GetProductsViewModel(int numberOfProducts, bool randomProducts, int baseProductId)
        {
            if (numberOfProducts <= 0 || baseProductId <= 0)
            {
                return null;
            }

            var baseProduct = this.Context.Products.FirstOrDefault(product => product.Id == baseProductId);
            var products = this.Context.Products.Where(product => product.Category.Id == baseProduct.Category.Id && product.Id != baseProductId).ToList();

            if (products.Count < numberOfProducts)
            {
                return null;
            }

            if (!randomProducts || products.Count - numberOfProducts <= 0)
            {
                return products
                    .Select(product => new ProductViewModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = "€ " + product.Prices.FirstOrDefault(price => price.Currency.IsoCode == "EUR").Value,
                        CategorySortingRule = product.Category.SortingRule,
                        DefaultImageName = product.Images.FirstOrDefault(image => image.isDefault == true).File
                    })
                    .Take(numberOfProducts)
                    .ToList();
            }

            var randomCount = products.Count - numberOfProducts;
            int index = new Random().Next(1,randomCount);
            return products
                    .Skip(index)
                    .Select(product => new ProductViewModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = "€ " + product.Prices.FirstOrDefault(price => price.Currency.IsoCode == "EUR").Value,
                        CategorySortingRule = product.Category.SortingRule,
                        DefaultImageName = product.Images.FirstOrDefault(image => image.isDefault == true).File
                    })
                    .Take(numberOfProducts)
                    .ToList();
        }

        public ICollection<ProductViewModel> GetProductsViewModel(PageEnumerator pageType, int page, string sorting)
        {
            var pageCount = Convert.ToInt32(pageType);
            var sortRule = this.Context.SortingRules.FirstOrDefault(sort => sort.Name == sorting);
            page -= 1;

            if (sortRule == null || page < 0)
            {
                return null;
            }

            var products = this.Context
                .Products
                .Where(product => product.IsActive)
                .Select(product => new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = "€ " + product.Prices.FirstOrDefault(price => price.Currency.IsoCode == "EUR").Value,
                    DefaultImageName = product.Images
                                              .FirstOrDefault(image => image.isDefault == true)
                                              .File

                })
                .ToList();

            return products
                   .OrderBy(sortRule.ProductSortParameter + " " + sortRule.SortingType)
                   .Skip(page * pageCount)
                   .Take(pageCount)
                   .ToList();
        }

        public int GetProductPagesCount(PageEnumerator elementsPerPage)
        {
            var productCount = this.Context.Products.Where(product => product.IsActive).Count(product => product.IsActive);
            int pageEleemnts = (int)elementsPerPage;

            return (int)Math.Ceiling((decimal)(productCount / pageEleemnts));
        }

        public ICollection<GroupViewModel> GetGroupsViewModel()
        {
            var groups = this.Context.Groups
                .OrderBy(group => group.SortingRule)
                .Select(group => new GroupViewModel
                {
                    Id = group.Id,
                    Name = group.Name,
                    Categories = group.Categories
                        .OrderBy(cat => cat.SortingRule)
                        .Select(cat => new CategoryViewModel
                        {
                            Id = cat.Id,
                            Name = cat.Name,
                            Image = cat.Image
                        }).ToList()
                })
                .ToList();

            return groups;
        }

        public GroupViewModel GetGroupById(int id)
        {
            var findedGroup = this.Context
                 .Groups
                 .Where(group => group.Categories.Count > 0)
                 .Select(group => new GroupViewModel
                 {
                     Name = group.Name,
                     Categories = group.Categories.OrderByDescending(category => category.SortingRule).Select(category => new CategoryViewModel
                     {
                         Name = category.Name,
                         Image = category.Image,
                         Id = category.Id
                     }).ToList(),
                     Id = group.Id

                 })
                 .FirstOrDefault(group => group.Id == id);

            return findedGroup;
        }

        public bool ValidateProduct(int productId)
        {
            var entity =
                this.Context.Products.Where(product => product.IsActive)
                    .FirstOrDefault(product => product.Id == productId);

            if (entity == null || entity.IsActive == false)
            {
                return false;
            }

            return true;
        }
    }
}