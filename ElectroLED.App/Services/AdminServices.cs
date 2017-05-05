using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using ElectroLED.app.Services;
using ElectroLED.App.Enums;
using ElectroLED.Models;
using ElectroLED.Models.ViewModels;

namespace ElectroLED.App.Services
{
    public class AdminServices : Service
    {
        public ICollection<ProductAdminViewModel> GetProductsAdminViewModel(PageEnumerator pageType, int page)
        {
            var pageCount = Convert.ToInt32(pageType);
            page -= 1;

            var products = this.Context
                .Products
                .Where(product => product.IsActive)
                .Select(product => new ProductAdminViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Prices = product.Prices,
                    IsActive = product.IsActive,
                    Category = product.Category,
                    Images = product.Images,
                    ProductParameters = product.ProductParameters,
                    Descriptions = product.Descriptions,
                    PreviewCount = product.PreviewCount,
                    SkuId = product.SkuId,
                    AddedDateTime = product.AddedDateTime,
                    ManifactureId = product.ManifactureId,
                    OnlineFromDate = product.OnlineFromDate,
                    Tag = product.Tag
                })
                .ToList();

            return products
                   .Skip(page * pageCount)
                   .Take(pageCount)
                   .ToList();
        }

        public Error GetErrorMessage(int errorCode)
        {
            var firstOrDefault = this.Context.Errors.FirstOrDefault(error => error.Id == errorCode);
            if (firstOrDefault != null)
                return firstOrDefault;

            return null;
        }
    }
}