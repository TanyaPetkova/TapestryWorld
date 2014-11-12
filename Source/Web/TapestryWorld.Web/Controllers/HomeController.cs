namespace TapestryWorld.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using TapestryWorld.Data;

    public class HomeController : BaseController
    {
        public HomeController(ITapestryWorldData data)
            : base(data)
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestImage()
        {
            return File("~/Content/Images/African Lions In The Savannah Grasses.jpg", "image/jpg");
        }
    }
}