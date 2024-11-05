namespace Toolkit.Mvvm.Infrastructure.Commands
{
    public delegate void CommandExceptionInvokedHandler(object s, CommandExceptionInvokedEventArgs e);
    public class CommandExceptionInvokedEventArgs : EventArgs
    {
        public CommandExceptionInvokedEventArgs(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; }
    }
}