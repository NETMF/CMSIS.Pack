using System.Collections.Generic;
using System.Linq;
using Sprache;

namespace SemVer.NET
{
    /// <summary>Grammar and parser for Semantic Version strings</summary>
    /// <remarks>
    /// This class uses the Sprache parser Combinator library to provide 
    /// the core parsing support. A few key elements of the grammar are
    /// exposed for validation of components (such as when programatically
    /// constructing a new version the prerelease and build metadata identifiers
    /// require validation)
    /// </remarks>
    public static class Grammar
    {
        // For full details of the syntax (including formal BNF grammar)
        // see: https://github.com/mojombo/semver/blob/master/semver.md

        private static Parser<char> Range( char start, char end )
            => Parse.Chars( Enumerable.Range( start, end ).Select( i => ( char )i ).ToArray( ) );

        // primitive single char parser monads
        private static Parser<char> Dot = Parse.Char('.');
        private static Parser<char> Zero = Parse.Char( '0' );
        private static Parser<char> Dash = Parse.Char( '-' );
        private static Parser<char> StartBuild = Parse.Char( '+' );
        private static Parser<char> StartPreRelease = Dash;

        // single char parser combinator monads
        private static Parser<char> Letter = Range('a','z').Or( Range('A','Z'));
        private static Parser<char> NonDigit = Letter.Or( Dash );
        private static Parser<char> NonZeroDigit = Range( '1', '9' );
        private static Parser<char> Digit = Zero.Or( NonZeroDigit );
        private static Parser<char> IdentifierChar = Digit.Or( NonDigit );
        private static Parser<char> LeadingV = Parse.Chars( 'v', 'V' );

        // char sequence parser combinator monads
        private static Parser<IEnumerable<char>> IdentifierCharacters = IdentifierChar.AtLeastOnce();
        private static Parser<IEnumerable<char>> Digits = Digit.AtLeastOnce();

        private static Parser<IEnumerable<char>> NumericIdentifier
            = Zero.Once()
             .Or( NonZeroDigit.Once().Concat( Digits ) )
             .Or( NonZeroDigit.Once() );

        private static Parser<IEnumerable<char>> AlphaNumericIdentifier
            = IdentifierCharacters.Concat( NonDigit.Once().Concat( IdentifierCharacters ) )
              .Or( IdentifierCharacters.Concat( NonDigit.Once() ) )
              .Or( NonDigit.Once().Concat( IdentifierCharacters ) )
              .Or( NonDigit.Once() );

        /// <summary>Parser monad for a semantic version Build Metadata Identifier</summary>
        public static Parser<string> BuildIdentifier = AlphaNumericIdentifier
                                                      .Or( Digits )
                                                      .Text();

        /// <summary>Parser monad for a semantic version Prerelease Identifier</summary>
        public static Parser<string> PrereleaseIdentifier = AlphaNumericIdentifier
                                                            .Or( NumericIdentifier )
                                                            .Text();

        /// <summary>Parser monad to parse a dot separated sequence of Build Metadata Identifiers</summary>
        public static Parser<IEnumerable<string>> DotSeparatedBuildIdentifiers = BuildIdentifier.DelimitedBy( Dot );

        /// <summary>Parser monad to parse a dot separated sequence of Prerelease Identifiers</summary>
        public static Parser<IEnumerable<string>> DotSeparatedReleaseIdentifiers = PrereleaseIdentifier.DelimitedBy( Dot );

        /// <summary>Parser monad to parse the non leading 0 sequence of digits for the Major, Minor, or Patch build numbers</summary>
        public static Parser<string> BuildNumber = NumericIdentifier.Text();

        /// <summary>Parser monad to parse a semantic version string into a <see cref="ParseResult"/></summary>
        public static Parser<ParseResult> SemanticVersion
            = from leadingV in LeadingV.Optional()
              from major in BuildNumber
              from sep1 in Dot
              from minor in BuildNumber
              from patch in ( from sep2 in Dot
                              from patchValue in BuildNumber
                              select patchValue
                            ).Optional()
              from preRelease in ( from start in StartPreRelease
                                   from preRelIds in DotSeparatedReleaseIdentifiers
                                   select preRelIds
                                 ).Optional()
              from buildMetadata in ( from start in StartBuild
                                      from buildIds in DotSeparatedBuildIdentifiers
                                      select buildIds
                                    ).Optional()
              select new ParseResult( leadingV.IsDefined ? new char?( leadingV.Get() ) : null
                                    , major
                                    , minor
                                    , patch.GetOrElse( string.Empty )
                                    , preRelease.GetOrElse( Enumerable.Empty<string>( ) )
                                    , buildMetadata.GetOrElse( Enumerable.Empty<string>( ) )
                                    );
    }
}
