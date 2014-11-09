namespace TapestryWorld.Web.Controllers
{
    using System.Web.Mvc;

    using TapestryWorld.Data;
    using TapestryWorld.Data.Common.Repository;
    using TapestryWorld.Data.Models;

    public class HomeController : Controller
    {
        private IRepository<Tapestry> tapestries;

        //Poor man's DI
        public HomeController()
            : this(new GenericRepository<Tapestry>(new ApplicationDbContext()))
        {
        }

        public HomeController(IRepository<Tapestry> tapestries)
        {
            this.tapestries = tapestries;
        }

        public ActionResult Index()
        {
            var tapestries = this.tapestries.All();
            return View(tapestries);
        }
    }
}