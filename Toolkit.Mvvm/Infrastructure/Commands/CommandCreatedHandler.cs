namespace Toolkit.Mvvm.Infrastructure.Commands
{
    public delegate void CommandCreatedHandler(object s, CommandCreatedArgs e);

    public class CommandCreatedArgs : EventArgs
    {
        public CommandCreatedArgs(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}