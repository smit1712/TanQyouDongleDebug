using System.Collections.Generic;
using TanQyouDongle.Models;

namespace TanQyouDongle.BusinessLayer
{
    public interface IBlueToothService
    {
        List<Device> GetConnectedDevices();
        void SelectDevice(Device device);
    }

}
