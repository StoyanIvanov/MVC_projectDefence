namespace ElectroLED.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SortingRule
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string RuleSorting { get; set; }

        public string ProductSortParameter { get; set; }
        public string SortingType { get; set; }
    }
}
