namespace TapestryWorld.Web.ViewModels.Comments
{
    using System;
    using AutoMapper;
    using TapestryWorld.Data.Models;
    using TapestryWorld.Web.Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(m => m.AuthorName, opt => opt.MapFrom(c => c.Author.UserName))
                .ReverseMap();
        }
    }
}