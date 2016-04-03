using System;
using System.Globalization;
using System.Linq;
using Sprache;

namespace CMSIS.Pack.PackDescription
{
    internal static class Parsers
    {
        internal static Parser<int> Integer( int minDigits, int maxDigitis )
        {
            return from value in Parse.Digit.Repeat( minDigits, maxDigitis ).Text( )
                   select int.Parse( value );
        }

        internal static Parser<decimal> Double = from value in Parse.Decimal
                                                 select decimal.Parse( value, CultureInfo.CurrentCulture );

        internal static Parser<decimal> ScaledDecimal = from signMul in Parse.Char('-').Return(-1).Or( Parse.Return( 1 ))
                                                        from value in Parse.Digit.AtLeastOnce( ).Text( )
                                                        from scale in ScaledIntMultiplier
                                                        select signMul * decimal.Parse( value ) * scale;

        internal static Parser<int> ScaledIntMultiplier = Parse.Chars( 'k', 'K' ).Return( 1024 )
                                                               .Or( Parse.Chars( 'm', 'M' ).Return( 1024 * 1024 ) )
                                                               .Or( Parse.Return( 1 ) );

        internal static bool IsIntegerScaleChar( char arg )
        {
            return arg == 'k'
                || arg == 'K'
                || arg == 'm'
                || arg == 'M';
        }
    }
}
