namespace Toolkit.Mvvm.Infrastructure.Commands
{
    public delegate void CommandCanExecuteFinishedHandler(object s, CommandCanExecuteFinishedArgs e);

    public class CommandCanExecuteFinishedArgs : EventArgs
    {
        public CommandCanExecuteFinishedArgs(bool result, string name)
        {
            Result = result;
            Name = name;
        }

        public bool Result { get; }
        public string Name { get; }
    }
}