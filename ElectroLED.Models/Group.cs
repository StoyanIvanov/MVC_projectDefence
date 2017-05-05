namespace ElectroLED.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Group
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int SortingRule { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
