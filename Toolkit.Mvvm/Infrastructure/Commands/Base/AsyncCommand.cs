using System.Windows.Input;
using Toolkit.Mvvm.Abstractions.Commands;

namespace Toolkit.Mvvm.Infrastructure.Commands.Base
{
    public abstract class AsyncCommand : IAsyncCommand
    {
        public event CommandExceptionInvokedHandler? ExceptionInvoked;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public abstract bool CanExecute(object parameter);
        public abstract Task ExecuteAsync(object parameter);
        bool ICommand.CanExecute(object parameter) => CanExecute(parameter);
        void ICommand.Execute(object parameter)
        {
            try
            {
                ExecuteAsync(parameter).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ExceptionInvoked?.Invoke(this, new CommandExceptionInvokedEventArgs(ex));
            }
        }

        public void RaiseCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();
    }
}
