using System.Runtime.CompilerServices;
using Toolkit.Mvvm.Infrastructure.Commands.Base;

namespace Toolkit.Mvvm.Infrastructure.Commands
{
    public sealed class LambdaCommand : Command
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool>? _canExecute;
        private readonly string _memberName;
        private readonly static string _defaultMemberName = "<No name>";

        public event CommandCreatedHandler? Created;
        public event CommandCanExecuteFinishedHandler? CanExecuteFinished;
        public event CommandExecutedHandler? Executed;

        public LambdaCommand(
            Action<object> execute,
            Func<object, bool> canExecute,
            [CallerMemberName] string memberName = null!) : this(execute, memberName)
        {
            _canExecute = canExecute;
        }

        public LambdaCommand(
            Action<object> execute,
            [CallerMemberName] string memberName = null!)
        {
            _execute = execute;
            _memberName = memberName ?? _defaultMemberName;

            Created?.Invoke(this, new CommandCreatedArgs(_memberName));
        }

        public override bool CanExecute(object parameter)
        {
            bool result = _canExecute?.Invoke(parameter) ?? true;

            CanExecuteFinished?.Invoke(this, new CommandCanExecuteFinishedArgs(result, _memberName));

            return result;
        }
        public override void Execute(object parameter)
        {
            _execute(parameter);

            Executed?.Invoke(this, new CommandExecutedEventArgs(_memberName));
        }
    }
}
