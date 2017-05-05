namespace ElectroLED.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Currency
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string IsoCode { get; set; }

        public string Symbol { get; set; }

    }
}
