namespace ElectroLED.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Language
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string CultureName { get; set; }
    }
}
