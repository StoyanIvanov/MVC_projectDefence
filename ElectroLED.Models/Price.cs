namespace ElectroLED.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Price
    {
        [Key]
        public int Id { get; set; }

        public double Value { get; set; }

        public virtual Product Product { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
