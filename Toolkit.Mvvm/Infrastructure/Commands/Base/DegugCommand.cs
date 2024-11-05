using System.Diagnostics;

namespace Toolkit.Mvvm.Infrastructure.Commands.Base
{
    /// <summary>
    ///  A command that allows you to determine whether the binding has been performed, as well as check the received argument
    /// </summary>
    public class DegugCommand : MarkupExtensionCommand
    {
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter)
        {
            Debugger.Break();
        }
    }
}
