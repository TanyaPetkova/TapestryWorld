namespace TapestryWorld.Web.ViewModels.Tapestry
{
    using System;

    using AutoMapper;

    using TapestryWorld.Data.Models;
    using TapestryWorld.Web.Infrastructure.Mapping;

    public class TapestryDetailsViewModel : IMapFrom<Tapestry>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string TapestryName { get; set; }

        public string DesignerName { get; set; }

        public decimal TapestryPrice { get; set; }

        public bool InStock { get; set; }

        public StitchType StitchType { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int ImageId { get; set; }

        public byte[] ImageContent { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Tapestry, TapestryDetailsViewModel>()
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(t => t.Category.Name))
                .ForMember(m => m.TapestryName, opt => opt.MapFrom(t => t.Name))
                .ForMember(m => m.Width, opt => opt.MapFrom(t => t.Dimension.Width))
                .ForMember(m => m.Height, opt => opt.MapFrom(t => t.Dimension.Height))
                .ForMember(m => m.ImageId, opt => opt.MapFrom(t => t.Image.Id))
                .ForMember(m => m.ImageContent, opt => opt.MapFrom(t => t.Image.Content))
                .ForMember(m => m.TapestryPrice, opt => opt.MapFrom(t => t.Price))
                .ReverseMap();
        }
    }
}