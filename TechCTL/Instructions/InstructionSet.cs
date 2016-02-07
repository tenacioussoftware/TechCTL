using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCTL.Instructions
{
    public interface IInstructionSet
    {
        string Name { get; set; }
        List<IInstruction> Instructions { get; set; }
    }

    public class InstructionSet : IInstructionSet
    {
        public string Name { get; set; }
        public List<IInstruction> Instructions { get; set; }
    }
}
