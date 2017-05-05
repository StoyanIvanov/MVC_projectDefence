namespace ElectroLED.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProductImage
    {
        [Key]
        public int Key { get; set; }

        public string File { get; set; }

        [Required]
        public int Width { get; set; }

        [Required]
        public int Height { get; set; }

        public string PathFromRoot { get; set; }

        public bool isDefault { get; set; }

        public virtual Product Product { get; set; }
    }
}