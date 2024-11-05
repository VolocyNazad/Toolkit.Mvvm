using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Toolkit.Mvvm.ViewModels.Base
{
    public abstract class ValidableViewModel : ViewModel, INotifyDataErrorInfo
    {
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        protected void RaiseErrorChanged([CallerMemberName] string propertyName = null!)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        protected void RaiseErrorsChanged(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                RaiseErrorChanged(propertyName);
            }
        }

        protected void Validate([CallerMemberName] string propertyName = null!) => RaiseErrorChanged(propertyName);
        protected bool ValidableSet<T>(ref T field, T value, [CallerMemberName] string propertyName = null!)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            field = value;
            RaisePropertyChanged(propertyName);
            RaiseErrorChanged(propertyName);
            return true;
        }
        public abstract IEnumerable GetErrors(string propertyName);
        public abstract bool HasErrors { get; }
    }
}
