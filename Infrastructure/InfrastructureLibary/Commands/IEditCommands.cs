using Prism.Commands;

namespace InfrastructureLibary.Commands
{
    public interface IEditCommands
    {
        public CompositeCommand Command01 { get; }
        public CompositeCommand Command02 { get; }
        public CompositeCommand Command03 { get; }
        public CompositeCommand Command04 { get; }
        public CompositeCommand Command05 { get; }

    }
}
