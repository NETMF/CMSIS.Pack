using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SemVer.NET;
using Sprache;

namespace CMSIS.Pack
{
    // CMSIS-Pack uses a relaxed syntax for semantic versions.
    // Deviations from the official spec are:
    // 1) Trailing 0s on Minor and Patch are ignored
    // 2) Patch is optional, if not present a default of 0 is assumed
    // 3) The hyphen prerelease delimiter is optional if the first
    //    character of the prerelease identifier is a letter
    //
    // This utility class provides for relaxed parsing to generate
    // a full SemanticVersion that, when converted back to a string
    // will conform to the SemanticVersion 2.0.0 specs. Thus, this
    // class serves to normalize the nonstandard versions into the
    // standard form.
    internal class VersionParser
    {
        internal static SemanticVersion Parse( string version)
        {
            var parts = Grammar.SemanticVersion.Parse( version );

            // handle case #2
            var patch = string.IsNullOrWhiteSpace( parts.Patch ) ? "0" : parts.Patch;

            // handle case #1
            patch = patch.Length > 1 ? patch.TrimEnd('0') : patch;
            var minor = parts.Minor.Length > 1 ? parts.Minor.TrimEnd('0') : parts.Minor;

            if( parts.LeadingV.HasValue )
                throw new FormatException( "Leading 'v' characters not supported in CMSIS-PACK Versions" );

            return new SemanticVersion( BigInteger.Parse( parts.Major )
                                      , BigInteger.Parse( minor )
                                      , BigInteger.Parse( patch )
                                      , GetPrereleaseQualifiers( parts.Prerelease )
                                      , parts.BuildMetadata?.Identifiers ?? Enumerable.Empty<string>( )
                                      );
        }

        private static IEnumerable<string> GetPrereleaseQualifiers( VersionQualifier qualifier )
        {
            if( qualifier == null )
                yield break;

            var firstIdentifier = qualifier.Identifiers.FirstOrDefault( );
            if( firstIdentifier == null )
                yield break;

            // handles case #3
            if( char.IsLetter( qualifier.LeadingChar ) )
                firstIdentifier = $"{qualifier.LeadingChar}{firstIdentifier}";

            yield return firstIdentifier;

            foreach( var identifier in qualifier.Identifiers.Skip( 1 ) )
                yield return identifier;
        }
    }
}
