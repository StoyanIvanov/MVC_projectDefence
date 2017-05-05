namespace ElectroLED.Models.ViewModels
{
    using System.Collections.Generic;

    public class GroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryViewModel> Categories { get; set; }
    }
}
