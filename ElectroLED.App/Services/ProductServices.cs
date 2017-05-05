namespace ElectroLED.app.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Models.ViewModels;

    public class ProductServices : Service
    {
        public List<Product> GetRecomendetProducts(int productsCount)
        {
            var products =
                this.Context.Products.Where(product => product.IsActive)
                    .OrderBy(product => product.PreviewCount)
                    .Take(productsCount)
                    .ToList();
            return products;
        }

        public ProductDetailViewModel GetProductDetails(int productId)
        {
            var productEntity =
                this.Context.Products
                    .FirstOrDefault(product => product.IsActive && product.Id == productId);
            if (productEntity?.Prices.FirstOrDefault(price => price.Currency.IsoCode == "EUR") == null)
            {
                return null;
            }

            var productDetails = new ProductDetailViewModel()
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Images = productEntity.Images,
                Descriptions = productEntity.Descriptions,
                ProductParameters = productEntity.ProductParameters,
                Price = "€ " + productEntity.Prices.FirstOrDefault(price => price.Currency.IsoCode == "EUR").Value
            };

            return productDetails;
        }

    }
}