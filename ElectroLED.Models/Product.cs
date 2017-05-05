namespace ElectroLED.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime AddedDateTime { get; set; }

        public DateTime OnlineFromDate { get; set; }

        public virtual ICollection<ProductImage> Images { get; set; }

        public virtual ICollection<Description> Descriptions { get; set; }

        public virtual ICollection<ProductParameter> ProductParameters { get; set; }

        public virtual ICollection<Price> Prices { get; set; }

        public string SkuId { get; set; }

        public string ManifactureId { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public string Tag { get; set; }

        public virtual Category Category { get; set; }
        public int? PreviewCount { get; set; }


    }
}