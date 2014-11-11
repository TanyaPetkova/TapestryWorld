namespace TapestryWorld.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using TapestryWorld.Data.Common.Repository;
    using TapestryWorld.Data.Models;
    using TapestryWorld.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private IRepository<Tapestry> tapestries;

        public HomeController(IRepository<Tapestry> tapestries)
        {
            this.tapestries = tapestries;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestImage()
        {
            return File("~/Content/3866_African Lions In The Savannah Grasses.jpg", "image/jpg");
        }
    }
}