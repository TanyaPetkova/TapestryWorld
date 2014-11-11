namespace TapestryWorld.Web.Controllers
{
    using System.Web.Mvc;

    using TapestryWorld.Data.Models;

    public abstract class BaseController : Controller
    {
        protected User CurrentUser { get; set; }

        [NonAction]
        public void SystemSettings()
        {
        }
    }
}