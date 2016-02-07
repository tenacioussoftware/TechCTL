using System;
using System.Collections.Generic;
using System.Linq;

namespace TechCTL.Devices
{
    public interface IDeviceManager
    {
        List<IDevice> Devices { get; set; }

        IDevice GetDevice(string name);
        string GetInstructionString(string deviceName, string instructionSetName, string instructionName);
        List<IDevice> GetDevicesOfType(DeviceClass deviceClass);
        List<IDevice> GetDevicesOfType(string deviceClass);
    }

    public class DeviceManager : IDeviceManager
    {
        public List<IDevice> Devices { get; set; }

        public IDevice GetDevice(string name)
        {
            return Devices.FirstOrDefault(d => d.Name.Equals(name));
        }

        public string GetInstructionString(String deviceName, String instructionSetName, String instructionName)
        {
            return Devices?.FirstOrDefault(d => d.Name.Equals(deviceName))
                .InstructionSets?.FirstOrDefault(iSet => iSet.Name.Equals(instructionSetName))
                .Instructions?.FirstOrDefault(i=> i.Name.Equals(instructionName)).InstructionString;
        }

        public List<IDevice> GetDevicesOfType(DeviceClass deviceClass)
        {
            var type = Devices?.Where(d => d.Classification != null && d.Classification.Equals(deviceClass));
            return Devices?.Where(d => d.Classification != null && d.Classification.Equals(deviceClass)).ToList();
        }

        public List<IDevice> GetDevicesOfType(string deviceClass)
        {
            return Devices?.Where(d => d.Classification != null && d.Classification.Name.Equals(deviceClass)).ToList();
        }

        
    }
}
