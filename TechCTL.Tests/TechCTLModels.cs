using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCTL.Devices;
using TechCTL.Instructions;
using Xunit;


namespace TechCTL.Tests
{
    public class TechCTLModels
    {
        [Theory]
        [InlineData("Living Room TV")]
        public void GetDevice(string deviceName)
        {
            var deviceManager = Substitute.For<DeviceManager>();
            deviceManager.Devices = new List<IDevice>() {
                new Device()
                {
                    Name = deviceName
                }
            };
            
            var device = deviceManager.GetDevice(deviceName);

            deviceManager.Received().GetDevice(Arg.Any<string>());
            Assert.Equal(deviceName, device.Name);
        }

        [Theory]
        [InlineData("Living Room TV", "Default","Volume Up", "0x000")]
        [InlineData("Home Theater", "Custom", "Mute", "0x000")]
        public void GetInstructionString(string deviceName, string instructionSetName, string instructionName, string instructionString)
        {
            var deviceManager = new DeviceManager();
            deviceManager.Devices = new List<IDevice>() {
                new Device()
                {
                    Name = deviceName,
                    InstructionSets = new List<InstructionSet>() { 
                        new InstructionSet()
                        {
                            Name = instructionSetName,
                            Instructions = new List<IInstruction>()
                            {
                                {
                                    new Instruction()
                                    {
                                        Name = instructionName,
                                        InstructionString = instructionString
                                    }
                                }
                            }
                        }
                    }
                }
            };

            Assert.Equal(instructionString, deviceManager.GetInstructionString(deviceName, instructionSetName, instructionName));
        }

        [Theory]
        [InlineData("DVD")]
        [InlineData("TV")]
        [InlineData("Projector")]
        public void GetDevicesOfType(string classificationName)
        {
            var deviceManager = new DeviceManager();
            var classification = new DeviceClass()
            {
                Name = classificationName
            };

            deviceManager.Devices = new List<IDevice>() {
                new Device()
                {
                    Classification = classification
                }
            };
            
            var devicesByClassification = deviceManager.GetDevicesOfType(classification);

            Assert.Equal(1, devicesByClassification.Count());
            Assert.Equal(classificationName, devicesByClassification.FirstOrDefault().Classification.Name);

            var devicesByClassificationName = deviceManager.GetDevicesOfType(classification);

            Assert.Equal(1, devicesByClassificationName.Count());
            Assert.Equal(classificationName, devicesByClassificationName.FirstOrDefault().Classification.Name);
        }
    }
}
