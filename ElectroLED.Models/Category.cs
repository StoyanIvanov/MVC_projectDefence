namespace ElectroLED.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int SortingRule { get; set; }
        public string Image { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}