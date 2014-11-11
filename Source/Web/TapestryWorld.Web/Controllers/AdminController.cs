namespace TapestryWorld.Web.Controllers
{
    using System.Web.Mvc;

    [Authorize(Roles = "")]
    public abstract class AdminController : BaseController
    {
    }
}