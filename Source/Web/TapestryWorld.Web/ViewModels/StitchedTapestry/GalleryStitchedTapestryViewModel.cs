namespace TapestryWorld.Web.ViewModels.StitchedTapestry
{
    using System;

    using AutoMapper;

    using TapestryWorld.Data.Models;
    using TapestryWorld.Web.Infrastructure.Mapping;

    public class GalleryStitchedTapestryViewModel : IMapFrom<StitchedTapestry>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public byte[] ImageContent { get; set; }

        public string AuthorName { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<StitchedTapestry, GalleryStitchedTapestryViewModel>()
                .ForMember(m => m.AuthorName, opt => opt.MapFrom(t => t.Author.UserName))
                .ForMember(m => m.ImageContent, opt => opt.MapFrom(t => t.Image.Content))
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(t => t.Category.Name))
                .ReverseMap();
        }
    }
}