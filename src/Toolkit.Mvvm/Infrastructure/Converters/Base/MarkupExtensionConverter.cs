using System.Globalization;
using System.Windows.Data;
using System.Workflow.ComponentModel.Serialization;

namespace Toolkit.Mvvm.Infrastructure.Converters.Base
{
    public abstract class MarkupExtensionConverter : MarkupExtension, IValueConverter
    {
        protected const string ConvertBackException = "Reverse conversion is not supported";

        public override object ProvideValue(IServiceProvider provider) => this;
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException(ConvertBackException);
        }
    }
}
