using System;
using System.Globalization;
using System.Linq;
using Sprache;

namespace CMSIS.Pack.PackDescription
{
    internal static class Parsers
    {
        internal static bool IsIntegerScaleChar( char arg )
        {
            return arg == 'k'
                || arg == 'K'
                || arg == 'm'
                || arg == 'M';
        }

        internal static Parser<int> Integer( int minDigits, int maxDigitis )
        {
            return from value in Parse.Digit.Repeat( minDigits, maxDigitis ).Text( )
                   select int.Parse( value );
        }

        // Official W3C XSD specs require 2 digits for the month and day
        // However, many PDSC files in the wild only have one, thus this
        // parser handles the incorrectly formed dates
        internal static Parser<DateTime> DateTime = from year in Integer( 4, 4 )
                                           from sep in Parse.Char( '-' )
                                           from month in Integer( 1, 2 )
                                           from sep2 in Parse.Char( '-' )
                                           from day in Integer( 1, 2 )
                                           select new DateTime( year, month, day );

        internal static Parser<double> Double = from value in Parse.Decimal
                                       select double.Parse( value, CultureInfo.CurrentCulture );

        internal static Parser<double> ScaledInteger = from value in Parse.Digit.AtLeastOnce( ).Text( )
                                              from scale in ScaledIntMultiplier
                                              select ( double )int.Parse( value ) * scale;

        static Parser<int> ScaledIntMultiplier = Parse.Chars( 'k', 'K' ).Return( 1024 )
                                                      .Or( Parse.Chars( 'm', 'M' ).Return( 1024 * 1024 ) )
                                                      .Or( Parse.Return( 1 ) );

        static Parser<double> NonConformantDecimal = ScaledInteger.Or( Double );
    }
}
