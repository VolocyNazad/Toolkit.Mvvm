using System.Runtime.CompilerServices;

namespace Toolkit.Mvvm.ViewModels.Base
{
    public abstract partial class ViewModel
    {
        public readonly ref struct SetValueResult<T>
        {
            public readonly bool Result;
            public readonly T? OldValue;
            public readonly T? NewValue;
            public readonly string PropertyName;
            public readonly Action<string> OnPropertyChanged;

            internal SetValueResult(bool result, T? oldValue, T? newValue, string propertyName, Action<string> onPropertyChanged)
            {
                Result = result;
                OldValue = oldValue;
                NewValue = newValue;
                PropertyName = propertyName;
                OnPropertyChanged = onPropertyChanged;
            }

            public SetValueResult<T> ThenCallPropertyChanged(string propertyName)
            {
                if (Result) OnPropertyChanged(propertyName);

                return this;
            }
            public SetValueResult<T> ThenCallPropertiesChanged(params string[] propertyNames)
            {
                if (Result)
                {
                    foreach (var propertyName in propertyNames)
                    {
                        OnPropertyChanged(propertyName);
                    }
                }

                return this;
            }

            public SetValueResult<T> ThenAnyway(Action<T?> action)
            {
                action(NewValue);

                return this;
            }
            public SetValueResult<T> ThenAnyway(Action<T?, T?> action)
            {
                action(OldValue, NewValue);

                return this;
            }
            public SetValueResult<T> ThenAnyway(Action action)
            {
                action();

                return this;
            }

            public SetValueResult<T> Then(Action<T?, T?> action)
            {
                if (Result) action(OldValue, NewValue);

                return this;
            }
            public SetValueResult<T> Then(Action<T?> action)
            {
                if (Result) action(NewValue);

                return this;
            }
            public SetValueResult<T> Then(Action action)
            {
                if (Result) action();

                return this;
            }

            public SetValueResult<T> ThenAsync(Func<Task> action)
            {
                if (Result) Task.Run(() => action());

                return this;
            }

            public SetValueResult<T> ThenIf(Func<T?, T?, bool> valueChecker, Action<T?, T?> action)
            {
                if (Result && valueChecker(OldValue, NewValue)) action(OldValue, NewValue);

                return this;
            }
            public SetValueResult<T> ThenIf(Func<T?, T?, bool> valueChecker, Action<T?> action)
            {
                if (Result && valueChecker(OldValue, NewValue)) action(NewValue);

                return this;
            }
            public SetValueResult<T> ThenIf(Func<T?, T?, bool> valueChecker, Action action)
            {
                if (Result && valueChecker(OldValue, NewValue)) action();

                return this;
            }
            public SetValueResult<T> ThenIf(Func<T?, bool> valueChecker, Action<T?, T?> action)
            {
                if (Result && valueChecker(NewValue)) action(OldValue, NewValue);

                return this;
            }
            public SetValueResult<T> ThenIf(Func<T?, bool> valueChecker, Action<T?> action)
            {
                if (Result && valueChecker(NewValue)) action(NewValue);

                return this;
            }
            public SetValueResult<T> ThenIf(Func<T?, bool> valueChecker, Action action)
            {
                if (Result && valueChecker(NewValue)) action();

                return this;
            }
            public SetValueResult<T> ThenIf(Func<bool> valueChecker, Action<T?> action)
            {
                if (Result && valueChecker()) action(NewValue);

                return this;
            }
            public SetValueResult<T> ThenIf(Func<bool> valueChecker, Action<T?, T?> action)
            {
                if (Result && valueChecker()) action(OldValue, NewValue);

                return this;
            }
            public SetValueResult<T> ThenIf(Func<bool> valueChecker, Action action)
            {
                if (Result && valueChecker()) action();

                return this;
            }

            public SetValueResult<T> ThenIfAnyway(Func<T?, T?, bool> valueChecker, Action<T?, T?> action)
            {
                if (valueChecker(OldValue, NewValue)) action(OldValue, NewValue);

                return this;
            }
            public SetValueResult<T> ThenIfAnyway(Func<T?, T?, bool> valueChecker, Action<T?> action)
            {
                if (valueChecker(OldValue, NewValue)) action(NewValue);

                return this;
            }
            public SetValueResult<T> ThenIfAnyway(Func<T?, T?, bool> valueChecker, Action action)
            {
                if (valueChecker(OldValue, NewValue)) action();

                return this;
            }
            public SetValueResult<T> ThenIfAnyway(Func<T?, bool> valueChecker, Action<T?, T?> action)
            {
                if (valueChecker(NewValue)) action(OldValue, NewValue);

                return this;
            }
            public SetValueResult<T> ThenIfAnyway(Func<T?, bool> valueChecker, Action<T?> action)
            {
                if (valueChecker(NewValue)) action(NewValue);

                return this;
            }
            public SetValueResult<T> ThenIfAnyway(Func<T?, bool> valueChecker, Action action)
            {
                if (valueChecker(NewValue)) action();

                return this;
            }
            public SetValueResult<T> ThenIfAnyway(Func<bool> valueChecker, Action<T?, T?> action)
            {
                if (valueChecker()) action(OldValue, NewValue);

                return this;
            }
            public SetValueResult<T> ThenIfAnyway(Func<bool> valueChecker, Action<T?> action)
            {
                if (valueChecker()) action(NewValue);

                return this;
            }
            public SetValueResult<T> ThenIfAnyway(Func<bool> valueChecker, Action action)
            {
                if (valueChecker()) action();

                return this;
            }

            public SetValueResult<T> ThenIfElse(Func<T?, T?, bool> valueChecker, Action<T?, T?> actionTrue, Action<T?, T?> actionFalse)
            {
                if (Result && valueChecker(OldValue, NewValue)) actionTrue(OldValue, NewValue);
                else if (Result && valueChecker(OldValue, NewValue) is false) actionFalse(OldValue, NewValue);
                return this;
            }
            public SetValueResult<T> ThenIfElse(Func<T?, T?, bool> valueChecker, Action<T?> actionTrue, Action<T?> actionFalse)
            {
                if (Result && valueChecker(OldValue, NewValue)) actionTrue(NewValue);
                else if (Result && valueChecker(OldValue, NewValue) is false) actionFalse(NewValue);
                return this;
            }
            public SetValueResult<T> ThenIfElse(Func<T?, T?, bool> valueChecker, Action actionTrue, Action actionFalse)
            {
                if (Result && valueChecker(OldValue, NewValue)) actionTrue();
                else if (Result && valueChecker(OldValue, NewValue) is false) actionFalse();
                return this;
            }
            public SetValueResult<T> ThenIfElse(Func<T?, bool> valueChecker, Action<T?, T?> actionTrue, Action<T?, T?> actionFalse)
            {
                if (Result && valueChecker(NewValue)) actionTrue(OldValue, NewValue);
                else if (Result && valueChecker(NewValue) is false) actionFalse(OldValue, NewValue);
                return this;
            }
            public SetValueResult<T> ThenIfElse(Func<T?, bool> valueChecker, Action<T?> actionTrue, Action<T?> actionFalse)
            {
                if (Result && valueChecker(NewValue)) actionTrue(NewValue);
                else if (Result && valueChecker(NewValue) is false) actionFalse(NewValue);
                return this;
            }
            public SetValueResult<T> ThenIfElse(Func<T?, bool> valueChecker, Action actionTrue, Action actionFalse)
            {
                if (Result && valueChecker(NewValue)) actionTrue();
                else if (Result && valueChecker(NewValue) is false) actionFalse();
                return this;
            }
            public SetValueResult<T> ThenIfElse(Func<bool> valueChecker, Action<T?, T?> actionTrue, Action<T?, T?> actionFalse)
            {
                if (Result && valueChecker()) actionTrue(OldValue, NewValue);
                else if (Result && valueChecker() is false) actionFalse(OldValue, NewValue);
                return this;
            }
            public SetValueResult<T> ThenIfElse(Func<bool> valueChecker, Action<T?> actionTrue, Action<T?> actionFalse)
            {
                if (Result && valueChecker()) actionTrue(NewValue);
                else if (Result && valueChecker() is false) actionFalse(NewValue);
                return this;
            }
            public SetValueResult<T> ThenIfElse(Func<bool> valueChecker, Action actionTrue, Action actionFalse)
            {
                if (Result && valueChecker()) actionTrue();
                else if (Result && valueChecker() is false) actionFalse();
                return this;
            }

            public SetValueResult<T> ThenIfElseAnyway(Func<T?, T?, bool> valueChecker, Action<T?, T?> actionTrue, Action<T?, T?> actionFalse)
            {
                if (valueChecker(OldValue, NewValue)) actionTrue(OldValue, NewValue);
                else if (valueChecker(OldValue, NewValue) is false) actionFalse(OldValue, NewValue);
                return this;
            }
            public SetValueResult<T> ThenIfElseAnyway(Func<T?, T?, bool> valueChecker, Action<T?> actionTrue, Action<T?> actionFalse)
            {
                if (valueChecker(OldValue, NewValue)) actionTrue(NewValue);
                else if (valueChecker(OldValue, NewValue) is false) actionFalse(NewValue);
                return this;
            }
            public SetValueResult<T> ThenIfElseAnyway(Func<T?, T?, bool> valueChecker, Action actionTrue, Action actionFalse)
            {
                if (valueChecker(OldValue, NewValue)) actionTrue();
                else if (valueChecker(OldValue, NewValue) is false) actionFalse();
                return this;
            }
            public SetValueResult<T> ThenIfElseAnyway(Func<T?, bool> valueChecker, Action<T?, T?> actionTrue, Action<T?, T?> actionFalse)
            {
                if (valueChecker(NewValue)) actionTrue(OldValue, NewValue);
                else if (valueChecker(NewValue) is false) actionFalse(OldValue, NewValue);
                return this;
            }
            public SetValueResult<T> ThenIfElseAnyway(Func<T?, bool> valueChecker, Action<T?> actionTrue, Action<T?> actionFalse)
            {
                if (valueChecker(NewValue)) actionTrue(NewValue);
                else if (valueChecker(NewValue) is false) actionFalse(NewValue);
                return this;
            }
            public SetValueResult<T> ThenIfElseAnyway(Func<T?, bool> valueChecker, Action actionTrue, Action actionFalse)
            {
                if (valueChecker(NewValue)) actionTrue();
                else if (valueChecker(NewValue) is false) actionFalse();
                return this;
            }
            public SetValueResult<T> ThenIfElseAnyway(Func<bool> valueChecker, Action<T?, T?> actionTrue, Action<T?, T?> actionFalse)
            {
                if (valueChecker()) actionTrue(OldValue, NewValue);
                else if (valueChecker() is false) actionFalse(OldValue, NewValue);
                return this;
            }
            public SetValueResult<T> ThenIfElseAnyway(Func<bool> valueChecker, Action<T?> actionTrue, Action<T?> actionFalse)
            {
                if (valueChecker()) actionTrue(NewValue);
                else if (valueChecker() is false) actionFalse(NewValue);
                return this;
            }
            public SetValueResult<T> ThenIfElseAnyway(Func<bool> valueChecker, Action actionTrue, Action actionFalse)
            {
                if (valueChecker()) actionTrue();
                else if (valueChecker() is false) actionFalse();
                return this;
            }
        }

        protected SetValueResult<T> NoisySetValueIf<T>(ref T field, T value, Func<bool> valueChecker, [CallerMemberName] string propertyName = null!)
        {
            if (Equals(field, value) || valueChecker() == false)
                return new SetValueResult<T>(false, field, value, propertyName, RaisePropertyChanged);

            var oldValue = field;
            field = value;
            RaiseNoisyPropertyChanged(propertyName);

            return new SetValueResult<T>(true, oldValue, value, propertyName, RaisePropertyChanged);
        }

        protected SetValueResult<T> NoisySetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null!)
        {
            if (Equals(field, value))
                return new SetValueResult<T>(false, field, value, propertyName, RaisePropertyChanged);

            var oldValue = field;
            field = value;
            RaiseNoisyPropertyChanged(propertyName);

            return new SetValueResult<T>(true, oldValue, value, propertyName, RaisePropertyChanged);
        }
        protected SetValueResult<T> SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null!)
        {
            if (Equals(field, value))
                return new SetValueResult<T>(false, field, value, propertyName, RaisePropertyChanged);

            var oldValue = field;
            field = value;
            RaisePropertyChanged(propertyName);

            return new SetValueResult<T>(true, oldValue, value, propertyName, RaisePropertyChanged);
        }

        [Obsolete]
        protected SetValueResult<T> ExternalSetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null!)
        {
            if (Equals(field, value))
                return new SetValueResult<T>(false, field, value, propertyName, RaisePropertyChanged);

            var oldValue = field;
            field = value;
            RaiseNoisyPropertyChanged(propertyName);

            return new SetValueResult<T>(true, oldValue, value, propertyName, RaisePropertyChanged);
        }

        protected SetValueResult<T> SetValueIf<T>(ref T field, T value, Func<bool> valueChecker, [CallerMemberName] string propertyName = null!)
        {
            if (Equals(field, value) || valueChecker() == false)
                return new SetValueResult<T>(false, field, value, propertyName, RaisePropertyChanged);

            var oldValue = field;
            field = value;

            RaisePropertyChanged(propertyName);

            return new SetValueResult<T>(true, oldValue, value, propertyName, RaisePropertyChanged);
        }
        protected SetValueResult<T> SetValueIf<T>(ref T field, T value, Func<T, bool> valueChecker, [CallerMemberName] string propertyName = null!)
        {
            if (Equals(field, value) || valueChecker(value) is false)
                return new SetValueResult<T>(false, field, value, propertyName, RaisePropertyChanged);

            var oldValue = field;
            field = value;
            RaisePropertyChanged(propertyName);

            return new SetValueResult<T>(true, oldValue, value, propertyName, RaisePropertyChanged);
        }
    }
}
