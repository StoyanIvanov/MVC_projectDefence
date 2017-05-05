namespace ElectroLED.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProductParameter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }

        public virtual Language Language { get; set; }
    }
}
