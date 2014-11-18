namespace TapestryWorld.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using TapestryWorld.Data;
    using TapestryWorld.Data.Common;
    using TapestryWorld.Web.ViewModels.Home;
    using TapestryWorld.Web.ViewModels.Tapestry;

    public class TapestryController : BaseController
    {
        public TapestryController(ITapestryWorldData data)
            : base(data)
        {
        }

        [Authorize]
        public ActionResult All(int? id)
        {
            int pageNumber = id.GetValueOrDefault(1);

            var tapestries = this.Data
                .Tapestries
                .All()
                .Project()
                .To<TapestryMainViewModel>()
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * GlobalConstants.PageSize)
                .Take(GlobalConstants.PageSize)
                .ToList();

            ViewBag.Pages = Math.Ceiling((double)this.Data.Tapestries.All().Count() / GlobalConstants.PageSize);

            if (tapestries == null)
            {
                throw new HttpException(404, "Tapestries not found!");
            }

            return View(tapestries);
        }

        public ActionResult Details(int id)
        {
            var tapestry = this.Data
                .Tapestries
                .All()
                .Where(t => t.Id == id)
                .Project()
                .To<TapestryDetailsViewModel>()
                .FirstOrDefault();

            if (tapestry == null)
            {
                throw new HttpException(404, "Tapestry not found!");
            }

            return this.View(tapestry);
        }

        public ActionResult GetCategories()
        {
            var categories = this.Data
                  .Categories
                  .All()
                  .Select(c => new SelectListItem
                  {
                      Value = c.Id.ToString(),
                      Text = c.Name
                  });

            return this.Json(categories, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ReadTapestries([DataSourceRequest]DataSourceRequest request, int? categoryId)
        {
            var tapestryQuery = this.Data.Tapestries.All();

            if (categoryId != null)
            {
                tapestryQuery = tapestryQuery.Where(t => t.CategoryId == categoryId.Value);
            }

            var tapestries = tapestryQuery
             .Project()
             .To<TapestryMainViewModel>();

            ViewBag.Pages = Math.Ceiling((double)this.Data.Tapestries.All().Count() / GlobalConstants.PageSize);

            return Json(tapestries.ToDataSourceResult(request));
        }
    }
}