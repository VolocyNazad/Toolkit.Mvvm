using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace Toolkit.Mvvm.ViewModels.Base
{

    public abstract partial class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected bool PropertyChangingDisabled { get; set; }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null!)
        {
            if (PropertyChangingDisabled) return;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void RaisePropertiesChanged(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                RaisePropertyChanged(propertyName);
            }
        }
        protected void RaiseNoisyPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            if (PropertyChangingDisabled) return;
            if (PropertyChanged is null) return;

            PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);

            Delegate[] delegateArray = PropertyChanged.GetInvocationList();

            foreach (Delegate action in delegateArray)
            {
                if (action.Target is DispatcherObject dispatcherObject)
                {
                    dispatcherObject.Dispatcher.Invoke(action, DispatcherPriority.Background, this, args);
                }
                else action.DynamicInvoke(this, args);
            }
        }
        protected void RaiseNoisyPropertiesChanged(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                RaisePropertyChanged(propertyName);
            }
        }

        protected bool NoisySet<T>(ref T field, T value, [CallerMemberName] string propertyName = null!)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            field = value;
            RaiseNoisyPropertyChanged(propertyName);

            return true;
        }
        protected bool TrySet<T>(ref T field, T value, [CallerMemberName] string propertyName = null!)
        {
            try
            {
                if (EqualityComparer<T>.Default.Equals(field, value)) return false;

                field = value;
                RaisePropertyChanged(propertyName);
                return true;
            }
            catch (Exception)
            {
                RaisePropertyChanged(propertyName);
                return false;
            }
        }
        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null!)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            field = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
        protected bool SetAnyway<T>(ref T field, T value, [CallerMemberName] string propertyName = null!)
        {
            field = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
