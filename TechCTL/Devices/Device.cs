using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCTL.Instructions;

namespace TechCTL.Devices
{
    public interface IDevice
    {
        string Name { get; set; }
        List<InstructionSet> InstructionSets { get; set; }
        DeviceClass Classification { get; set; }
    }

    public class Device : IDevice
    {
        public string Name { get; set; }
        public List<InstructionSet> InstructionSets { get; set; }
        public DeviceClass Classification { get; set; }
    }
}
