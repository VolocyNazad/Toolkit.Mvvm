using System.Runtime.CompilerServices;

namespace Toolkit.Mvvm.ViewModels.Base
{
    public abstract partial class ViewModel
    {
        public readonly ref struct SetValueResult<T>
        {
            private readonly bool _result;
            private readonly T? _oldValue;
            private readonly T? _newValue;
            private readonly Action<string> _onPropertyChanged;

            internal SetValueResult(bool result, T? oldValue, T? newValue, Action<string> onPropertyChanged)
            {
                _result = result;
                _oldValue = oldValue;
                _newValue = newValue;
                _onPropertyChanged = onPropertyChanged;
            }

            public SetValueResult<T> ThenCallPropertyChanged(string propertyName)
            {
                if (_result) _onPropertyChanged(propertyName);

                return this;
            }
            public SetValueResult<T> ThenCallPropertiesChanged(params string[] propertyNames)
            {
                if (_result)
                {
                    foreach (var propertyName in propertyNames)
                    {
                        _onPropertyChanged(propertyName);
                    }
                }

                return this;
            }

            public SetValueResult<T> ThenAnyway(Action<T?> action)
            {
                action(_newValue);

                return this;
            }
            public SetValueResult<T> ThenAnyway(Action<T?, T?> action)
            {
                action(_oldValue, _newValue);

                return this;
            }
            public SetValueResult<T> ThenAnyway(Action action)
            {
                action();

                return this;
            }

            public SetValueResult<T> Then(Action<T?, T?> action)
            {
                if (_result) action(_oldValue, _newValue);

                return this;
            }
            public SetValueResult<T> Then(Action<T?> action)
            {
                if (_result) action(_newValue);

                return this;
            }
            public SetValueResult<T> Then(Action action)
            {
                if (_result) action();

                return this;
            }

            public SetValueResult<T> ThenAsync(Func<Task> action)
            {
                if (_result) Task.Run(() => action());

                return this;
            }

            public SetValueResult<T> ThenIf(Func<T?, T?, bool> valueChecker, Action<T?, T?> action)
            {
                if (_result && valueChecker(_oldValue, _newValue)) action(_oldValue, _newValue);

                return this;
            }
            public SetValueResult<T> ThenIf(Func<T?, T?, bool> valueChecker, Action<T?> action)
            {
                if (_result && valueChecker(_oldValue, _newValue)) action(_newValue);

                return this;
            }
            public SetValueResult<T> ThenIf(Func<T?, T?, bool> valueChecker, Action action)
            {
                if (_result && valueChecker(_oldValue, _newValue)) action();

                return this;
            }
            public SetValueResult<T> ThenIf(Func<T?, bool> valueChecker, Action<T?, T?> action)
            {
                if (_result && valueChecker(_newValue)) action(_oldValue, _newValue);

                return this;
            }
            public SetValueResult<T> ThenIf(Func<T?, bool> valueChecker, Action<T?> action)
            {
                if (_result && valueChecker(_newValue)) action(_newValue);

                return this;
            }
            public SetValueResult<T> ThenIf(Func<T?, bool> valueChecker, Action action)
            {
                if (_result && valueChecker(_newValue)) action();

                return this;
            }
            public SetValueResult<T> ThenIf(Func<bool> valueChecker, Action<T?> action)
            {
                if (_result && valueChecker()) action(_newValue);

                return this;
            }
            public SetValueResult<T> ThenIf(Func<bool> valueChecker, Action<T?, T?> action)
            {
                if (_result && valueChecker()) action(_oldValue, _newValue);

                return this;
            }
            public SetValueResult<T> ThenIf(Func<bool> valueChecker, Action action)
            {
                if (_result && valueChecker()) action();

                return this;
            }

            public SetValueResult<T> ThenIfAnyway(Func<T?, T?, bool> valueChecker, Action<T?, T?> action)
            {
                if (valueChecker(_oldValue, _newValue)) action(_oldValue, _newValue);

                return this;
            }
            public SetValueResult<T> ThenIfAnyway(Func<T?, T?, bool> valueChecker, Action<T?> action)
            {
                if (valueChecker(_oldValue, _newValue)) action(_newValue);

                return this;
            }
            public SetValueResult<T> ThenIfAnyway(Func<T?, T?, bool> valueChecker, Action action)
            {
                if (valueChecker(_oldValue, _newValue)) action();

                return this;
            }
            public SetValueResult<T> ThenIfAnyway(Func<T?, bool> valueChecker, Action<T?, T?> action)
            {
                if (valueChecker(_newValue)) action(_oldValue, _newValue);

                return this;
            }
            public SetValueResult<T> ThenIfAnyway(Func<T?, bool> valueChecker, Action<T?> action)
            {
                if (valueChecker(_newValue)) action(_newValue);

                return this;
            }
            public SetValueResult<T> ThenIfAnyway(Func<T?, bool> valueChecker, Action action)
            {
                if (valueChecker(_newValue)) action();

                return this;
            }
            public SetValueResult<T> ThenIfAnyway(Func<bool> valueChecker, Action<T?, T?> action)
            {
                if (valueChecker()) action(_oldValue, _newValue);

                return this;
            }
            public SetValueResult<T> ThenIfAnyway(Func<bool> valueChecker, Action<T?> action)
            {
                if (valueChecker()) action(_newValue);

                return this;
            }
            public SetValueResult<T> ThenIfAnyway(Func<bool> valueChecker, Action action)
            {
                if (valueChecker()) action();

                return this;
            }

            public SetValueResult<T> ThenIfElse(Func<T?, T?, bool> valueChecker, Action<T?, T?> actionTrue, Action<T?, T?> actionFalse)
            {
                if (_result && valueChecker(_oldValue, _newValue)) actionTrue(_oldValue, _newValue);
                else if (_result && valueChecker(_oldValue, _newValue) is false) actionFalse(_oldValue, _newValue);
                return this;
            }
            public SetValueResult<T> ThenIfElse(Func<T?, T?, bool> valueChecker, Action<T?> actionTrue, Action<T?> actionFalse)
            {
                if (_result && valueChecker(_oldValue, _newValue)) actionTrue(_newValue);
                else if (_result && valueChecker(_oldValue, _newValue) is false) actionFalse(_newValue);
                return this;
            }
            public SetValueResult<T> ThenIfElse(Func<T?, T?, bool> valueChecker, Action actionTrue, Action actionFalse)
            {
                if (_result && valueChecker(_oldValue, _newValue)) actionTrue();
                else if (_result && valueChecker(_oldValue, _newValue) is false) actionFalse();
                return this;
            }
            public SetValueResult<T> ThenIfElse(Func<T?, bool> valueChecker, Action<T?, T?> actionTrue, Action<T?, T?> actionFalse)
            {
                if (_result && valueChecker(_newValue)) actionTrue(_oldValue, _newValue);
                else if (_result && valueChecker(_newValue) is false) actionFalse(_oldValue, _newValue);
                return this;
            }
            public SetValueResult<T> ThenIfElse(Func<T?, bool> valueChecker, Action<T?> actionTrue, Action<T?> actionFalse)
            {
                if (_result && valueChecker(_newValue)) actionTrue(_newValue);
                else if (_result && valueChecker(_newValue) is false) actionFalse(_newValue);
                return this;
            }
            public SetValueResult<T> ThenIfElse(Func<T?, bool> valueChecker, Action actionTrue, Action actionFalse)
            {
                if (_result && valueChecker(_newValue)) actionTrue();
                else if (_result && valueChecker(_newValue) is false) actionFalse();
                return this;
            }
            public SetValueResult<T> ThenIfElse(Func<bool> valueChecker, Action<T?, T?> actionTrue, Action<T?, T?> actionFalse)
            {
                if (_result && valueChecker()) actionTrue(_oldValue, _newValue);
                else if (_result && valueChecker() is false) actionFalse(_oldValue, _newValue);
                return this;
            }
            public SetValueResult<T> ThenIfElse(Func<bool> valueChecker, Action<T?> actionTrue, Action<T?> actionFalse)
            {
                if (_result && valueChecker()) actionTrue(_newValue);
                else if (_result && valueChecker() is false) actionFalse(_newValue);
                return this;
            }
            public SetValueResult<T> ThenIfElse(Func<bool> valueChecker, Action actionTrue, Action actionFalse)
            {
                if (_result && valueChecker()) actionTrue();
                else if (_result && valueChecker() is false) actionFalse();
                return this;
            }

            public SetValueResult<T> ThenIfElseAnyway(Func<T?, T?, bool> valueChecker, Action<T?, T?> actionTrue, Action<T?, T?> actionFalse)
            {
                if (valueChecker(_oldValue, _newValue)) actionTrue(_oldValue, _newValue);
                else if (valueChecker(_oldValue, _newValue) is false) actionFalse(_oldValue, _newValue);
                return this;
            }
            public SetValueResult<T> ThenIfElseAnyway(Func<T?, T?, bool> valueChecker, Action<T?> actionTrue, Action<T?> actionFalse)
            {
                if (valueChecker(_oldValue, _newValue)) actionTrue(_newValue);
                else if (valueChecker(_oldValue, _newValue) is false) actionFalse(_newValue);
                return this;
            }
            public SetValueResult<T> ThenIfElseAnyway(Func<T?, T?, bool> valueChecker, Action actionTrue, Action actionFalse)
            {
                if (valueChecker(_oldValue, _newValue)) actionTrue();
                else if (valueChecker(_oldValue, _newValue) is false) actionFalse();
                return this;
            }
            public SetValueResult<T> ThenIfElseAnyway(Func<T?, bool> valueChecker, Action<T?, T?> actionTrue, Action<T?, T?> actionFalse)
            {
                if (valueChecker(_newValue)) actionTrue(_oldValue, _newValue);
                else if (valueChecker(_newValue) is false) actionFalse(_oldValue, _newValue);
                return this;
            }
            public SetValueResult<T> ThenIfElseAnyway(Func<T?, bool> valueChecker, Action<T?> actionTrue, Action<T?> actionFalse)
            {
                if (valueChecker(_newValue)) actionTrue(_newValue);
                else if (valueChecker(_newValue) is false) actionFalse(_newValue);
                return this;
            }
            public SetValueResult<T> ThenIfElseAnyway(Func<T?, bool> valueChecker, Action actionTrue, Action actionFalse)
            {
                if (valueChecker(_newValue)) actionTrue();
                else if (valueChecker(_newValue) is false) actionFalse();
                return this;
            }
            public SetValueResult<T> ThenIfElseAnyway(Func<bool> valueChecker, Action<T?, T?> actionTrue, Action<T?, T?> actionFalse)
            {
                if (valueChecker()) actionTrue(_oldValue, _newValue);
                else if (valueChecker() is false) actionFalse(_oldValue, _newValue);
                return this;
            }
            public SetValueResult<T> ThenIfElseAnyway(Func<bool> valueChecker, Action<T?> actionTrue, Action<T?> actionFalse)
            {
                if (valueChecker()) actionTrue(_newValue);
                else if (valueChecker() is false) actionFalse(_newValue);
                return this;
            }
            public SetValueResult<T> ThenIfElseAnyway(Func<bool> valueChecker, Action actionTrue, Action actionFalse)
            {
                if (valueChecker()) actionTrue();
                else if (valueChecker() is false) actionFalse();
                return this;
            }
        }

        protected SetValueResult<T> SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null!)
        {
            if (Equals(field, value))
                return new SetValueResult<T>(false, field, value, RaisePropertyChanged);

            var oldValue = field;
            field = value;
            RaisePropertyChanged(propertyName);

            return new SetValueResult<T>(true, oldValue, value, RaisePropertyChanged);
        }
        protected SetValueResult<T> ExternalSetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null!)
        {
            if (Equals(field, value))
                return new SetValueResult<T>(false, field, value, RaisePropertyChanged);

            var oldValue = field;
            field = value;
            RaiseNoisyPropertyChanged(propertyName);

            return new SetValueResult<T>(true, oldValue, value, RaisePropertyChanged);
        }

        protected SetValueResult<T> SetValueIf<T>(ref T field, T value, Func<bool> valueChecker, [CallerMemberName] string propertyName = null!)
        {
            if (Equals(field, value) || valueChecker() == false)
                return new SetValueResult<T>(false, field, value, RaisePropertyChanged);

            var oldValue = field;
            field = value;

            RaisePropertyChanged(propertyName);

            return new SetValueResult<T>(true, oldValue, value, RaisePropertyChanged);
        }
        protected SetValueResult<T> SetValueIf<T>(ref T field, T value, Func<T, bool> valueChecker, [CallerMemberName] string propertyName = null!)
        {
            if (Equals(field, value) || valueChecker(value) is false)
                return new SetValueResult<T>(false, field, value, RaisePropertyChanged);

            var oldValue = field;
            field = value;
            RaisePropertyChanged(propertyName);

            return new SetValueResult<T>(true, oldValue, value, RaisePropertyChanged);
        }
    }
}
