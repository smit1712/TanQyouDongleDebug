using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TanQyouDongle.Models;
using Xamarin.Forms.Internals;

namespace TanQyouDongle.BusinessLayer
{
    public class BlueToothService : IBlueToothService
    {
        private IBluetoothLE _bluetoothLE;
        private IAdapter _adapter;

        public BlueToothService()
        {
            _bluetoothLE = CrossBluetoothLE.Current;
            _adapter = CrossBluetoothLE.Current.Adapter;
            _adapter.ScanMode = ScanMode.LowLatency;

            _bluetoothLE.StateChanged += (s, e) =>
            {
                StateChanged(s, e);
            };
        }

        public List<Device> GetConnectedDevices()
        {
            List<Device> devices = new List<Device>();

            List<IDevice> systemDevices = _adapter.GetSystemConnectedOrPairedDevices().ToList();
            systemDevices.ForEach(sd => devices.Add(new Device() { name = sd.Name, UniqueID = sd.Id }));

            return devices;
        }

        public async void SelectDevice(Device device)
        {
            try
            {
                IDevice ConnectedDevice = await _adapter.ConnectToKnownDeviceAsync(device.UniqueID);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        private void StateChanged(object s, BluetoothStateChangedArgs e)
        {
            Console.WriteLine(e.NewState);
        }
    }
}
