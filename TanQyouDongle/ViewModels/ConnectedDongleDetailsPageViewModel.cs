using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TanQyouDongle.BusinessLayer;
using TanQyouDongle.Models;

namespace TanQyouDongle.ViewModels
{
    public class ConnectedDongleDetailsPageViewModel : BindableBase, INavigationAware
    {
        private readonly IBlueToothService _blueToothService;
        private Device _device;

        public Device Device
        {
            get { return _device; }
            set { SetProperty(ref _device, value); }
        }

        public ConnectedDongleDetailsPageViewModel(IBlueToothService blueToothService)
        {
            _blueToothService = blueToothService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            parameters.TryGetValue("device", out _device);
            RaisePropertyChanged(nameof(Device));

            _blueToothService.SelectDevice(Device);
        }
    }
}
