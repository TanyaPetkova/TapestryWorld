namespace TapestryWorld.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using TapestryWorld.Data;
    using TapestryWorld.Web.Infrastructure.Services.Contracts;

    public class HomeController : BaseController
    {
        private IHomeService homeService;

        public HomeController(ITapestryWorldData data, IHomeService homeService)
            : base(data)
        {
            this.homeService = homeService;
        }

        //[OutputCache(Duration = 60 * 60)]
        public ActionResult Index()
        {
            return View(this.homeService.GetIndexViewModel(5));
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}