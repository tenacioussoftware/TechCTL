namespace TechCTL.Instructions
{
    public interface IInstruction
    {
        string Name { get; set; }
        string InstructionString { get; set; }
    }

    public class Instruction : IInstruction
    {
        public string Name { get; set; }
        public string InstructionString { get; set; }
    }
}