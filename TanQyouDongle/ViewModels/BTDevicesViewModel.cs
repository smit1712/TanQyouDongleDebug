using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TanQyouDongle.BusinessLayer;
using TanQyouDongle.Models;
using TanQyouDongle.Page;

namespace TanQyouDongle.ViewModels
{
    public class BTDevicesViewModel : BindableBase, INavigationAware
    {
        private readonly IBlueToothService _blueToothService;
        private readonly INavigationService _navigationService;


        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }


        private ObservableCollection<Device> _devices = new ObservableCollection<Device>();
        public ObservableCollection<Device> Devices
        {
            get { return _devices; }
            set { SetProperty(ref _devices, value); }
        }

        private Device _selectedDevice;
        public Device SelectedDevice
        {
            get { return _selectedDevice; }
            set { SetProperty(ref _selectedDevice, value, onChanged: DeviceSelected); }
        }

        private void DeviceSelected()
        {
            if (_selectedDevice == null) return;

            var parameters = new NavigationParameters
            {
                { "device", SelectedDevice }
            };

            _navigationService.NavigateAsync(nameof(ConnectedDongleDetailsPage),parameters);
        }

        public ICommand GetDevicesCommand { get; }
        public BTDevicesViewModel(IBlueToothService blueToothService, INavigationService navigationService)
        {
            _blueToothService = blueToothService;
            _navigationService = navigationService;

            GetDevicesCommand = new DelegateCommand(GetDevices);
        }

        private void GetDevices()
        {
            IsBusy = true;

            Devices = new ObservableCollection<Device>(_blueToothService.GetConnectedDevices());

            IsBusy = false;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            _selectedDevice = null;
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            GetDevices();
        }
    }
}
