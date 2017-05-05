namespace ElectroLED.Data
{
    using Models;
    using System.Data.Entity;

    public class ElectroLEDContext : DbContext
    {

        public ElectroLEDContext()
            : base("name=ElectroLED")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductParameter> ProductParameters { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<SortingRule> SortingRules { get; set; }

    }
}