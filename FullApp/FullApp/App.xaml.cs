using FullApp.Services;
using FullApp.Services.Interfaces;
using FullApp.Views;
using Prism.Forms.Regions.Mocks;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace FullApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = @"..\..\..\..\bin" };
        }

        /// <summary>
        /// 注册类型
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        /// <summary>
        /// 加载模块
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            string str = System.Environment.CurrentDirectory;
            var tempstr = Path.Combine(str, ".\\.\\.\\.\\bin");
            moduleCatalog.Initialize();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            regionAdapterMappings.RegisterMapping<StackPanel, StackPanelRegionAdapter>();
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
        }
    }
}
