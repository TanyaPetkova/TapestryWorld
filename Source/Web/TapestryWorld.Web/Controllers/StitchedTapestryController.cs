namespace TapestryWorld.Web.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using TapestryWorld.Data;
    using TapestryWorld.Web.ViewModels.Comments;
    using TapestryWorld.Web.ViewModels.StitchedTapestry;
    using TapestryWorld.Data.Models;

    [Authorize]
    public class StitchedTapestryController : BaseController
    {
        public StitchedTapestryController(ITapestryWorldData data)
            : base(data)
        {
        }

        [Authorize]
        public ActionResult Add()
        {
            var addStitchedTapestry = new AddStitchedTapestryViewModel
            {
                Categories = this.Data
                    .Categories
                    .All()
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
            };

            return this.View(addStitchedTapestry);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddStitchedTapestryViewModel tapestry)
        {
            if (tapestry != null && ModelState.IsValid)
            {
                var dbTapestry = AutoMapper.Mapper.Map<StitchedTapestry>(tapestry);
                dbTapestry.Author = this.UserProfile;
                if (tapestry.UploadedImage != null)
                {
                    using (var memory = new MemoryStream())
                    {
                        tapestry.UploadedImage.InputStream.CopyTo(memory);
                        var content = memory.GetBuffer();

                        dbTapestry.Image = new Image
                        {
                            Content = content,
                            FileExtension = tapestry.UploadedImage.FileName.Split(new char[] { '.' }).Last()
                        };
                    }
                }

                this.Data.StitchedTapestries.Add(dbTapestry);
                this.Data.SaveChanges();

                return RedirectToAction("Gallery", "StitchedTapestry");
            }

            return this.View(tapestry); 
        }

        public ActionResult All()
        {
            var tapestries = this.Data
                  .StitchedTapestries
                  .All()
                  .Project()
                  .To<GalleryStitchedTapestryViewModel>()
                  .ToList();
            return this.View(tapestries);
        }

        public ActionResult Details(int id)
        {
            var tapestry = this.Data
                .StitchedTapestries
                .All()
                .Where(t => t.Id == id)
                .OrderByDescending(c => c.Id)
                .Project()
                .To<StitchedTapestryDetailsViewModel>()
                .FirstOrDefault();

            if (tapestry == null)
            {
                throw new HttpException(404, "Tapestry not found!");
            }

            tapestry.Comments = this.Data
                .Comments
                .All()
                .Where(c => c.StitchedTapestryId == tapestry.Id)
                .Project()
                .To<CommentViewModel>()
                .ToList();

            return this.View(tapestry);
        }
    }
}