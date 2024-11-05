using System.Windows.Input;
using System.Workflow.ComponentModel.Serialization;

namespace Toolkit.Mvvm.Infrastructure.Commands.Base
{
    public abstract class MarkupExtensionCommand : MarkupExtension, ICommand
    {
        public override object ProvideValue(IServiceProvider serviceProvider) => this;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
