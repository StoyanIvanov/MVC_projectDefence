namespace ElectroLED.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string DefautImagePath { get; set; }
        public string DefaultImageName { get; set; }
        public int CategorySortingRule { get; set; }
    }
}
