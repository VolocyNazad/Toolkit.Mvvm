using System.Windows.Input;

namespace Toolkit.Mvvm.Abstractions.Commands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}
