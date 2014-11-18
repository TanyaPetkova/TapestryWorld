namespace TapestryWorld.Web.ViewModels.StitchedTapestry
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;

    using TapestryWorld.Data.Models;
    using TapestryWorld.Web.Infrastructure.Mapping;

    public class AddStitchedTapestryViewModel : IMapFrom<StitchedTapestry>
    {
        [Display(Name = "Choose Category")]
        [UIHint("DropDownList")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        [Required]
        [Display(Name = "Choose stitched tapestry image")]
        [UIHint("InputTypeFile")]
        public HttpPostedFileBase UploadedImage { get; set; }
    }
}