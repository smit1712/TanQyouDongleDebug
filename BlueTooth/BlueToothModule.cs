using BlueTooth.ViewModels;
using BlueTooth.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace BlueTooth
{
    public class BlueToothModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
        }
    }
}
