namespace TapestryWorld.Web.ViewModels.Home
{
    using TapestryWorld.Data.Models;
    using TapestryWorld.Web.Infrastructure.Mapping;

    public class IndexTapestryViewModel : IMapFrom<Tapestry>
    {
        public string Name { get; set; }
    }
}