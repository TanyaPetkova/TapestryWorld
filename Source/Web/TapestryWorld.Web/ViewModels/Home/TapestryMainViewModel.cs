namespace TapestryWorld.Web.ViewModels.Home
{
    using System;

    using AutoMapper;

    using TapestryWorld.Data.Models;
    using TapestryWorld.Web.Infrastructure.Mapping;

    public class TapestryMainViewModel : IMapFrom<Tapestry>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string TapestryName { get; set; }

        public decimal TapestryPrice { get; set; }
  
        public byte[] ImageContent { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Tapestry, TapestryMainViewModel>()
                .ForMember(m => m.TapestryName, opt => opt.MapFrom(t => t.Name))
                .ForMember(m => m.TapestryPrice, opt => opt.MapFrom(t => t.Price))
                .ForMember(m => m.ImageContent, opt => opt.MapFrom(t => t.Image.Content))
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(t => t.Category.Name))
                .ReverseMap();
        }
    }
}