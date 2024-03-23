using FullApp.Core;
using FullApp.Core.Mvvm;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace FullApp.Modules.HeaderModule
{
    public class HeaderModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public HeaderModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Header>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.HeaderRegion, "Header");
        }
    }
}