namespace ElectroLED.Models.ViewModels
{
    using System.Collections.Generic;

    public class ProductDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ProductImage> Images { get; set; }

        public virtual ICollection<Description> Descriptions { get; set; }

        public virtual ICollection<ProductParameter> ProductParameters { get; set; }

        public string Price { get; set; }

    }
}
