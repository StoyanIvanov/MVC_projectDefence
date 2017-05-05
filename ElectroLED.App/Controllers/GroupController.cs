namespace ElectroLED.App.Controllers
{
    using System.Web.Mvc;
    using Services;
    public class GroupController : Controller
    {
        private readonly GroupServices service;

        public GroupController()
        {
            this.service = new GroupServices();
        }

        // GET: Groups/5
        public ActionResult Select(int id)
        {
            if (!this.service.ValidateGroup(id))
            {
                return this.RedirectToAction("NotFound", "Home", new { message = "The selected Group not have categories" });

            }

            var group = this.service.GetGroupById(id);

            return this.View(group);
        }

    }
}