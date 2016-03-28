using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace NetmfPackInstaller
{
    [ValueConversion(typeof(LoadState),typeof(string))]
    public class LoadStateConverter
        : MarkupExtension
        , IValueConverter
    {
        public override object ProvideValue( IServiceProvider serviceProvider )
        {
            return this;
        }

        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
        {
             var state = (LoadState)value;
             switch( state )
             {
             case LoadState.LoadingIndex:
                 return "Loading Index";
             case LoadState.ParsingDescriptions:
                 return "Parsing Descriptors";
             case LoadState.Ready:
                 return "Ready";
             default:
                 return string.Empty;
             }
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
        {
            throw new NotSupportedException( );
        }
    }
}
