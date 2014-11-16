namespace TapestryWorld.Web.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using TapestryWorld.Data;
    using TapestryWorld.Web.Infrastructure.Services.Base;
    using TapestryWorld.Web.Infrastructure.Services.Contracts;
    using TapestryWorld.Web.ViewModels.Home;

    public class HomeService : BaseService, IHomeService
    {
        public HomeService(ITapestryWorldData data)
            : base(data)
        {
        }

        public IList<TapestryMainViewModel> GetIndexViewModel(int numberOfTapestries)
        {
            var tapestries = this.Data
                  .Tapestries
                  .All()
                  .OrderByDescending(x => x.SoldItems)
                  .Take(numberOfTapestries)
                  .Project()
                  .To<TapestryMainViewModel>()
                  .ToList();

            return tapestries;
        }
    }
}
