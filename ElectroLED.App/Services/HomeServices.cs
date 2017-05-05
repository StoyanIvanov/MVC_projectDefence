namespace ElectroLED.app.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using App.Enums;
    using Models.ViewModels;

    public class HomeServices : Service
    {

        public ICollection<ProductViewModel> GetRecomendetProducts()
        {
            int displayedRecomendetProducts = (int)PageEnumerator.RecomendetProducts;
            var products = this.Context.Products
                .Where(product => product.IsActive && product.Images.Count>0)
                .OrderByDescending(product => product.PreviewCount)
                .Select(product => new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = "€ " + product.Prices.FirstOrDefault(price => price.Currency.IsoCode == "EUR").Value,
                    DefaultImageName = product.Images.FirstOrDefault(image=>image.isDefault==true).File
                })
                .Take(displayedRecomendetProducts)
                .ToList();

            return products;
        }

        
    }
}