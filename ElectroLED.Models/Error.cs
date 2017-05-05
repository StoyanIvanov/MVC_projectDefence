namespace ElectroLED.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Error
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
