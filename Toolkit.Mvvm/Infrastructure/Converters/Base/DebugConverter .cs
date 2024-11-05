using System.Diagnostics;
using System.Globalization;

namespace Toolkit.Mvvm.Infrastructure.Converters.Base
{
    /// <summary>
    ///  A command that allows you to determine whether the binding has been performed, as well as check the received argument
    /// </summary>
    public class DebugConverter : MarkupExtensionConverter
    {
        public override object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            Debugger.Break();
            return value;
        }


        public override object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            Debugger.Break();
            return value;
        }
    }
}
