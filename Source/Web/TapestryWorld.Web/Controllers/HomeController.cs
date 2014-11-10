namespace TapestryWorld.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using TapestryWorld.Data.Common.Repository;
    using TapestryWorld.Data.Models;
    using TapestryWorld.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        private IRepository<Tapestry> tapestries;

        public HomeController(IRepository<Tapestry> tapestries)
        {
            this.tapestries = tapestries;
        }

        public ActionResult Index()
        {
            var tapestries = this.tapestries.All().Project().To<IndexTapestryViewModel>();

            return View(tapestries);
        }
    }
}