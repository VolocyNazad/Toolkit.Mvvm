namespace Toolkit.Mvvm.Infrastructure.Commands
{
    public delegate void CommandExecutedHandler(object s, CommandExecutedEventArgs e);

    public class CommandExecutedEventArgs : EventArgs
    {
        public CommandExecutedEventArgs(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}