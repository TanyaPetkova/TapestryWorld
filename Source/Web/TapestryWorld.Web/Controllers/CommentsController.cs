namespace TapestryWorld.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;

    using TapestryWorld.Data;
    using TapestryWorld.Data.Models;
    using TapestryWorld.Web.ViewModels.Comments;

    public class CommentsController : BaseController
    {
        public CommentsController(ITapestryWorldData data)
            : base(data)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(PostCommentViewModel comment)
        {
            if (comment != null && ModelState.IsValid)
            {
                var dbComment = Mapper.Map<Comment>(comment);
                dbComment.Author = this.UserProfile;
                var tapestry = this.Data
                    .StitchedTapestries
                    .GetById(comment.StitchedTapestryId);
                if (tapestry == null)
                {
                    throw new HttpException(404, "Tapestry not found");
                }

                tapestry.Comments.Add(dbComment);
                this.Data.SaveChanges();

                var viewModel = Mapper.Map<CommentViewModel>(dbComment);

                return PartialView("_CommentPartial", viewModel);
            }

            throw new HttpException(400, "Invalid comment");
        }
    }
}