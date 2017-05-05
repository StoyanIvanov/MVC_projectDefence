namespace ElectroLED.App.Services
{
    using System.Linq;
    using app.Services;


    public class GroupServices : Service
    {

        public bool ValidateGroup(int id)
        {
            if (!this.Context.Groups.Any(group => group.Id == id))
            {
                return false;
            }

            if (!this.Context.Groups.Any(group => group.Id == id && group.Categories.Count>0))
            {
                return false;
            }

            return true;
        }

    }
}