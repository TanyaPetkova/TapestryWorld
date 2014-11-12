namespace TapestryWorld.Web.Controllers
{
    using System.Web.Mvc;

    using TapestryWorld.Data;

    public abstract class BaseController : Controller
    {
        protected ITapestryWorldData data;

        public BaseController(ITapestryWorldData data)
        {
            this.data = data;  
        }
    }
}