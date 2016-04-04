using System.Linq;
using Sprache;

namespace CMSIS.Pack.PackDescription
{
    /// <summary>Parser to aid in gracefully handling invalid real world PDSC files</summary>
    /// <remarks>
    /// Many real world PDSC files fail a proper schema validation due to various issues. These
    /// parsers help to ensure that these files are still usable and that any files saved by
    /// this library will properly conform. (e.g. An invalid file loaded by this library, then
    /// saved again should pass a proper schema validation.) 
    /// </remarks>
    internal static class Parsers
    {
        internal static Parser<string> RestrictedString = Parse.LetterOrDigit
                                                               .Or( Parse.Chars('-','_'))
                                                               .AtLeastOnce()
                                                               .Token()
                                                               .Text();

        // The official XSD and documentation for the PSDC schema lists the decimal type for many values
        // (in particular the m and n values of the 'feature' element), however some existing and supposedly
        // validated PDSC files in the real world use scaled values like '512K', which obviously won't pass
        // as a standard XSD decimal type. This simple parser will parse the numeric part and the units part
        // then scale the numeric part accordingly. The result is a valid decimal that represents the original
        // (i.e. 512K will become 524288)
        internal static Parser<decimal> ScaledDecimal = from signMul in Parse.Char('-').Return(-1).Or( Parse.Return( 1 ))
                                                        from value in Parse.Digit.AtLeastOnce( ).Text( )
                                                        from scale in ScaledIntMultiplier
                                                        select signMul * decimal.Parse( value ) * scale;

        private static Parser<int> ScaledIntMultiplier = Parse.Chars( 'k', 'K' ).Return( 1024 )
                                                              .Or( Parse.Chars( 'm', 'M' ).Return( 1024 * 1024 ) )
                                                              .Or( Parse.Return( 1 ) );

    }
}
