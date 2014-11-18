namespace TapestryWorld.Web.ViewModels.StitchedTapestry
{
    using System.Collections.Generic;

    using AutoMapper;

    using TapestryWorld.Data.Models;
    using TapestryWorld.Web.Infrastructure.Mapping;
    using TapestryWorld.Web.ViewModels.Comments;

    public class StitchedTapestryDetailsViewModel : IMapFrom<StitchedTapestry>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int ImageId { get; set; }

        public byte[] ImageContent { get; set; }

        public string AuthorName { get; set; }

        public string CategoryName { get; set; }

        public virtual ICollection<CommentViewModel> Comments { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<StitchedTapestry, StitchedTapestryDetailsViewModel>()
                .ForMember(m => m.AuthorName, opt => opt.MapFrom(t => t.Author.UserName))
                .ForMember(m => m.ImageId, opt => opt.MapFrom(t => t.Image.Id))
                .ForMember(m => m.ImageContent, opt => opt.MapFrom(t => t.Image.Content))
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(t => t.Category.Name))
                .ReverseMap();
        }
    }
}