using Prism.Ioc;
using Prism.Modularity;
using TanQyouDongle.BusinessLayer;
using TanQyouDongle.Page;
using TanQyouDongle.ViewModels;
using TanQyouDongle.Views;

namespace TanQyouDongle
{
    public class TanQyouDongleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterSingleton<IBlueToothService, BlueToothService>();

            containerRegistry.RegisterForNavigation<BTDevicesView, BTDevicesViewModel>();
            containerRegistry.RegisterForNavigation<ConnectedDongleDetailsPage, ConnectedDongleDetailsPageViewModel>();
        }
    }
}
