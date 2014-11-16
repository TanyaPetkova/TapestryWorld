namespace TapestryWorld.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using TapestryWorld.Data;
    using TapestryWorld.Data.Models;

    public abstract class BaseController : Controller
    {
        public BaseController(ITapestryWorldData data)
        {
            this.Data = data;  
        }

        protected ITapestryWorldData Data { get; private set; }

        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.UserProfile = this.Data.Users.All().Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name).FirstOrDefault();
            return base.BeginExecute(requestContext, callback, state);
        }

        public ActionResult GetImage(int id)
        {
            var image = this.Data.Tapestries.GetById(id).Image;
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return File(image.Content, "image/jpg"); 
        }
    }
}