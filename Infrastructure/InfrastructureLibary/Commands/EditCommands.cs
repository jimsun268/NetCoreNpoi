using Prism.Commands;

namespace InfrastructureLibary.Commands
{
    public class EditCommands : IEditCommands
    {
        private CompositeCommand _command01 = new CompositeCommand();
        public CompositeCommand Command01
        {
            get { return _command01; }
        }
        private CompositeCommand _command02 = new CompositeCommand();
        public CompositeCommand Command02
        {
            get { return _command02; }
        }
        private CompositeCommand _command03 = new CompositeCommand();
        public CompositeCommand Command03
        {
            get { return _command03; }
        }
        private CompositeCommand _command04 = new CompositeCommand();
        public CompositeCommand Command04
        {
            get { return _command04; }
        }
            private CompositeCommand _command05 = new CompositeCommand();
        public CompositeCommand Command05
        {
            get { return _command05; }
        }
    }
}