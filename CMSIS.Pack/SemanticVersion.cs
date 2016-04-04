using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Sprache;

namespace CMSIS.Pack
{
    [Flags]
    public enum SemanticVersionOptions
    {
        None = 0,
        PatchOptional = 1,
        //...
        // TODO: Add options to allow build metadata in precedence checks
        //       see: https://github.com/mojombo/semver/issues/200
        // 
    }

    /// <summary>Version structure for versions based on Semantic Versioning v2.0 as defined by https://github.com/mojombo/semver/blob/master/semver.md </summary>
    /// <remarks>
    /// This class implements creating, parsing and comparing semantic version values. In
    /// addition to the standard support, this class includes an additional optional optimization
    /// where parsing a version string can assume a default patch value of 0 if none is specified.
    /// According to the formal Semantic Versioning v2.0 spec. the patch value is required, however
    /// some real world applications allow the looser definition.
    /// </remarks>
    public struct SemanticVersion
        : IComparable
        , IComparable<SemanticVersion>
        , IEquatable<SemanticVersion>
    {
        /// <summary>Constructs a semantic version from its independent parts</summary>
        /// <param name="major">Major version number</param>
        /// <param name="minor">Minor Version number</param>
        /// <param name="patch">Patch version number</param>
        /// <param name="preReleaseParts">Array of individual pre-release parts (not including the separating '.')</param>
        /// <param name="metadataParts">Array of individual Build Metadata parts (not including the separating '.')</param>
        public SemanticVersion( int major, int minor, int patch, IEnumerable<string> preReleaseParts, IEnumerable<string> metadataParts )
        {
            if( major < 0 )
                throw new ArgumentOutOfRangeException( nameof( major ) );

            if( minor < 0 )
                throw new ArgumentOutOfRangeException( nameof( minor ) );

            if( patch < 0 )
                throw new ArgumentOutOfRangeException( nameof( patch ) );

            Major = major;
            Minor = minor;
            Patch = patch;
            PreReleaseParts_ = ( preReleaseParts ?? Enumerable.Empty<string>() ).ToArray();
            BuildMetadata_ = ( metadataParts ?? Enumerable.Empty<string>() ).ToArray();

            // Validate each part conforms to an "identifier" as defined by the spec
            if( !ValidatePrereleaseIdentifierParts( PreReleaseParts_ ) )
                throw new ArgumentException( "Invalid identifier for pre-release part", nameof( preReleaseParts ) );

            if( !ValidateBuildIdentifierParts( BuildMetadata_ ) )
                throw new ArgumentException( "Invalid identifier for build metadata part", nameof( metadataParts ) );

            HashCode = null;
        }

        /// <summary>Constructs a semantic version from its independent parts</summary>
        /// <param name="major">Major version number</param>
        /// <param name="minor">Minor Version number</param>
        /// <param name="patch">Patch version number</param>
        public SemanticVersion( int major, int minor, int patch )
            : this( major
                  , minor
                  , patch
                  , null
                  , null
                  )
        {
        }

        /// <summary>Indicates if this version is a development version (e.g. Major Version == 0 )</summary>
        public bool IsDevelopment => Major == 0;

        /// <summary>Indicates if this version is a pre-release version (e.g. IsDevelopment or Has pre-release parts following the Patch)</summary>
        public bool IsPrerelease => IsDevelopment || PreReleaseParts.Count > 0;

        /// <summary>Indicates if this is a valid version</summary>
        public bool IsValid => Major >= 0 && Minor >= 0 && Patch >= 0;

        /// <summary>Major version number</summary>
        public int Major { get; }

        /// <summary>Minor version number</summary>
        public int Minor { get; }

        /// <summary>Patch version number</summary>
        public int Patch { get; }

        /// <inheritdoc/>
        public override int GetHashCode( )
        {
            // HashCode is the cached result value of the computed hash code determined
            // from the other read-only fields and therefore does not participate in the
            // computation of the hash.
#pragma warning disable RECS0025 // Non-readonly field referenced in 'GetHashCode()'
            // ReSharper disable NonReadonlyFieldInGetHashCode
            if( !HashCode.HasValue )
                HashCode = ComputeHashCode( );

            return HashCode.Value;
            // ReSharper restore NonReadonlyFieldInGetHashCode
#pragma warning restore RECS0025 // Non-readonly field referenced in 'GetHashCode()'
        }

        /// <inheritdoc/>
        public override bool Equals( object obj )
        {
            if( !( obj is SemanticVersion ) )
                return false;

            return Equals( ( SemanticVersion )obj );
        }

        /// <inheritdoc/>
        public bool Equals( SemanticVersion other )
        {
            return 0 == CompareTo( other );
        }

        /// <inheritdoc/>
        public int CompareTo( object obj )
        {
            if( !( obj is SemanticVersion ) )
                throw new ArgumentException( );

            return CompareTo( ( SemanticVersion )obj );
        }

        // Precedence Rules:
        // Paraphrased From http://semver.org/ Section 11
        // Precedence is determined by the first difference when comparing each of these
        // identifiers from left to right as follows:
        // 1) Major, minor, and patch versions are always compared numerically.
        // Example: 1.0.0 < 2.0.0 < 2.1.0 < 2.1.1.
        // 2) When major, minor, and patch are equal, a pre-release version has lower
        // precedence than a normal version.
        // Example: 1.0.0-alpha < 1.0.0.
        // 3) Precedence for two pre-release versions with the same major, minor, and
        // patch version MUST be determined by comparing each dot separated identifier
        // from left to right until a difference is found as follows:
        //     a) identifiers consisting of only digits are compared numerically
        //     b) identifiers with letters or hyphens are compared lexically in ASCII sort order.
        //     c) Numeric identifiers always have lower precedence than non-numeric identifiers.
        //     d) A larger set of pre-release fields has a higher precedence than a smaller set,
        //        if all of the preceding identifiers are equal.
        // Example: 1.0.0-alpha < 1.0.0-alpha.1 < 1.0.0-alpha.beta < 1.0.0-beta < 1.0.0-beta.2 < 1.0.0-beta.11 < 1.0.0-rc.1 < 1.0.0.
        /// <inheritdoc/>
        public int CompareTo( SemanticVersion other )
        {
            // Rule #1
            var retVal = Major.CompareTo( other.Major );
            if( retVal != 0 )
                return retVal;

            retVal = Minor.CompareTo( other.Minor );
            if( retVal != 0 )
                return retVal;

            retVal = Patch.CompareTo( other.Patch );
            if( retVal != 0 )
                return retVal;

            // Rule #2
            if( PreReleaseParts.Count == 0 && other.PreReleaseParts.Count == 0 )
                return 0;

            if( PreReleaseParts.Count == 0 )
                return 1;

            if( other.PreReleaseParts.Count == 0 )
                return -1;

            // Rules 3.a-c
            var partCount = Math.Min( PreReleaseParts.Count, other.PreReleaseParts.Count );
            for( var i = 0; i < partCount; ++i )
            {
                // rule 3.c
                retVal = string.Compare( PreReleaseParts[ i ], other.PreReleaseParts[ i ], StringComparison.Ordinal );
                if( retVal == 0 )
                    continue;

                // Rule 3.a
                int left, right;
                if( !int.TryParse( PreReleaseParts[ i ], out left )
                 || !int.TryParse( other.PreReleaseParts[ i ], out right )
                  )
                {
                    return retVal;
                }
                return left.CompareTo( right );
            }

            // Rule #3.d
            return PreReleaseParts.Count.CompareTo( other.PreReleaseParts.Count );
        }

        /// <summary>List of identifier parts forming the pre-release value</summary>
        /// <remarks>
        /// Pre-release values are optional and follow the patch with a '-'. The pre-release
        /// value can consist of multiple parts separated by a '.', this list contains the
        /// individual parts without the leading '-' or separating '.'. 
        /// </remarks>
        public IReadOnlyList<string> PreReleaseParts => Array.AsReadOnly( PreReleaseParts_ ?? EmptyStringArray );
        private readonly string[ ] PreReleaseParts_;

        /// <summary>List of identifier parts forming the build Metadata value</summary>
        /// <remarks>
        /// Metadata values are optional and follow the patch with a '+'. The Metadata
        /// value can consist of multiple parts separated by a '.', this list contains
        /// the individual parts without the leading '+' or separating '.'. 
        /// </remarks>
        public IReadOnlyList<string> BuildMetadata => Array.AsReadOnly( BuildMetadata_ ?? EmptyStringArray );
        private readonly string[ ] BuildMetadata_;

        /// <inheritdoc/>
        public override string ToString( ) => ToString( true );

        /// <summary>Creates a valid semantic version string from the component values of this version</summary>
        /// <param name="includeBuildMetadata">Flag to indicate if the Build Metadata should be included</param>
        /// <returns>Semantic version string for this version</returns>
        /// <remarks>
        /// The <paramref name="includeBuildMetadata"/> parameter is used to control whether the build information
        /// portion of the version is included or not. The Build Metadata is the only portion of the semantic 
        /// version that does not participate in precedence evaluation for comparing versions. 
        /// </remarks>
        public string ToString( bool includeBuildMetadata )
        {
            var bldr = new StringBuilder( string.Format( CultureInfo.InvariantCulture, "{0}.{1}.{2}", Major, Minor, Patch ) );
            if( PreReleaseParts.Count > 0 )
            {
                bldr.Append( '-' );
                bldr.Append( string.Join( ".", PreReleaseParts ) );
            }

            if( BuildMetadata.Count > 0 && includeBuildMetadata )
            {
                bldr.Append( '+' );
                bldr.Append( string.Join( ".", BuildMetadata ) );
            }

            return bldr.ToString( );
        }

        /// <summary>Parse a semantic version string into it's component parts</summary>
        /// <param name="versionString">String containing the version to parse</param>
        /// <returns>Parsed version details</returns>
        public static SemanticVersion Parse( string versionString ) => Parse( versionString, SemanticVersionOptions.None );

        /// <summary>Parse a semantic version string into it's component parts</summary>
        /// <param name="versionString">String containing the version to parse</param>
        /// <param name="patchOptional">Flag indicating non-standard optional default (0) for the patch if not present</param>
        /// <returns>Parsed version details</returns>
        /// <remarks>
        /// This overload of Parse allows for a non-standard version where the Patch value
        /// defaults to 0 if not present, instead of triggering an exception.
        /// </remarks>
        public static SemanticVersion Parse( string versionString, SemanticVersionOptions options )
        {
            try
            {
                var parts = SemanticVersionParser.Parse( versionString );
                return new SemanticVersion( parts, options );
            }
            catch( ParseException ex )
            {
                throw new FormatException("Invalid SemanticVersion", ex);
            }
        }

        /// <summary>Attempts to parse a version string into a new SemanticVersion instance</summary>
        /// <param name="versionString">String to parse</param>
        /// <param name="version">Version instance to construct</param>
        /// <returns>true if the string is a valid semantic version string that was successfully parsed into <paramref name="version"/></returns>
        public static bool TryParse( string versionString, out SemanticVersion version)
        {
            return TryParse( versionString, SemanticVersionOptions.None, out version );
        }

        /// <summary>Attempts to parse a version string into a new SemanticVersion instance</summary>
        /// <param name="versionString">String to parse</param>
        /// <param name="options">Options flags to control parsing variants and ambiguities in the spec</param>
        /// <param name="version">Version instance to construct</param>
        /// <returns>true if the string is a valid semantic version string that was successfully parsed into <paramref name="version"/></returns>
        public static bool TryParse( string versionString, SemanticVersionOptions options, out SemanticVersion version )
        {
            version = new SemanticVersion();
            var result = SemanticVersionParser.TryParse( versionString );
            if( !result.WasSuccessful )
                return false;

            version = new SemanticVersion( result.Value, options );
            return true;
        }

        /// <summary>Compares two <see cref="SemanticVersion"/> instances for equality</summary>
        /// <param name="lhs">Left hand side of the comparison</param>
        /// <param name="rhs">Right hand side of the comparison</param>
        /// <returns><see langword="true"/> if the two versions are equivalent</returns>
        public static bool operator ==( SemanticVersion lhs, SemanticVersion rhs )
        {
            return lhs.Equals( rhs );
        }

        /// <summary>Compares two <see cref="SemanticVersion"/> instances for inequality</summary>
        /// <param name="lhs">Left hand side of the comparison</param>
        /// <param name="rhs">Right hand side of the comparison</param>
        /// <returns><see langword="true"/> if the two versions are not equivalent</returns>
        public static bool operator !=( SemanticVersion lhs, SemanticVersion rhs )
        {
            return !lhs.Equals( rhs );
        }

        private static bool ValidateBuildIdentifierParts( IEnumerable<string> metadataParts )
        {
            var q = from part in metadataParts
                    let result = BuildIdentifier.End().TryParse( part )
                    where !result.WasSuccessful
                    select part;
            return !q.Any( );
        }

        private static bool ValidatePrereleaseIdentifierParts( IEnumerable<string> metadataParts )
        {
            var q = from part in metadataParts
                    let result = PrereleaseIdentifier.End( ).TryParse( part )
                    where !result.WasSuccessful
                    select part;
            return !q.Any( );
        }

        private int ComputeHashCode( ) => ToString( false ).GetHashCode( );

        // this is intentionally not a read-only field
        // its a private field and used like a C++ mutable.
        // It caches the HashCode that's expensive to compute
        // so it is only done once.
        private int? HashCode;

        // When using the default constructor the pre-release and build meta arrays will be null
        // The property accessors for those arrays will test for null and use this singleton empty
        // array if null to prevent null reference issues.
        static readonly string[] EmptyStringArray = new string [0];

        private SemanticVersion( ParseResult parts, SemanticVersionOptions options )
            : this( parts.Major
                  , parts.Minor
                  , parts.Patch.GetOrDefault( )
                  , parts.Prerelease
                  , parts.BuildMetadata
                  )
        {
            if( !options.HasFlag( SemanticVersionOptions.PatchOptional ) && !parts.Patch.IsDefined )
                throw new FormatException( "Patch component of Semantic Version is required" );
        }

        #region static parsers
        // For full details of the syntax (including formal BNF grammar)
        // see: https://github.com/mojombo/semver/blob/master/semver.md

        private class ParseResult
        {
            internal ParseResult( int major
                                , int minor
                                , IOption<int> patch
                                , IOption<IEnumerable<string>> prereleaseParts
                                , IOption<IEnumerable<string>> buildParts
                                )
            {
                Major = major;
                Minor = minor;
                Patch = patch;
                Prerelease = prereleaseParts.GetOrElse( Enumerable.Empty<string>() );
                BuildMetadata = buildParts.GetOrElse( Enumerable.Empty<string>() );
            }

            internal int Major { get; }
            internal int Minor { get; }
            internal IOption<int> Patch { get; }
            internal IEnumerable<string> Prerelease { get; }
            internal IEnumerable<string> BuildMetadata { get; }
        }

        private static Parser<char> Range( char start, char end ) => Sprache.Parse.Chars( Enumerable.Range( start, end ).Select( i=>(char)i ).ToArray() );
        
        private static Parser<char> Dot = Sprache.Parse.Char('.');
        private static Parser<char> Zero = Sprache.Parse.Char( '0' );
        private static Parser<char> Dash = Sprache.Parse.Char( '-' );

        private static Parser<char> StartBuild = Sprache.Parse.Char( '+' );
        private static Parser<char> StartPreRelease = Dash;

        private static Parser<char> Letter = Range('a','z').Or( Range('A','Z'));
        private static Parser<char> NonDigit = Letter.Or( Dash );
        private static Parser<char> NonZeroDigit = Range( '1', '9' );
        private static Parser<char> Digit = Zero.Or( NonZeroDigit );
        private static Parser<char> IdentifierChar = Digit.Or( NonDigit );

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


        private static Parser<string> BuildIdentifier = AlphaNumericIdentifier
                                                       .Or( Digits )
                                                       .Text();

        private static Parser<IEnumerable<string>> DotSeparatedBuildIdentifiers = BuildIdentifier.DelimitedBy( Dot );


        private static Parser<string> PrereleaseIdentifier = AlphaNumericIdentifier
                                                             .Or( NumericIdentifier )
                                                             .Text();

        private static Parser<IEnumerable<string>> DotSeparatedReleaseIdentifiers = PrereleaseIdentifier.DelimitedBy( Dot );

        private static Parser<int> BuildNumber = from numString in NumericIdentifier.Text()
                                                 select int.Parse( numString );

        private static Parser<ParseResult> SemanticVersionParser
            = from major in BuildNumber
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
              select new ParseResult( major, minor, patch, preRelease, buildMetadata );
        #endregion
    }
}