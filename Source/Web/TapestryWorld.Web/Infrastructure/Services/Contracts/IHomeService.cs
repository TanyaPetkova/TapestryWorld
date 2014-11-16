namespace TapestryWorld.Web.Infrastructure.Services.Contracts
{
    using System.Collections.Generic;
    using TapestryWorld.Web.ViewModels.Home;

    public interface IHomeService
    {
        IList<TapestryMainViewModel> GetIndexViewModel(int numberOfTapestries);
    }
}
