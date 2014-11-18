namespace TapestryWorld.Web.Areas.Administration.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using TapestryWorld.Data.Models;
    using TapestryWorld.Web.Infrastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [UIHint("String")]
        public string Name { get; set; }
    }
}