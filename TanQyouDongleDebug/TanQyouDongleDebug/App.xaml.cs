using Prism;
using Prism.Ioc;
using Prism.Modularity;
using TanQyouDongle;
using TanQyouDongle.ViewModels;
using TanQyouDongle.Views;
using TanQyouDongleDebug.ViewModels;
using TanQyouDongleDebug.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace TanQyouDongleDebug
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var result = await NavigationService.NavigateAsync($"NavigationPage/{nameof(BTDevicesView)}");
            System.Console.WriteLine(result.Success);
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<TanQyouDongleModule>(InitializationMode.WhenAvailable);
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}
