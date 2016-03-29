using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CMSIS.Pack
{
    /// <summary>Version structure for versions based on Semantic Versioning v2.0 as defined by http://semver.org </summary>
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
        public SemanticVersion( int major, int minor, int patch, string[] preReleaseParts, string[] metadataParts)
        {
            if( major < 0 )
                throw new ArgumentOutOfRangeException( nameof( major ) );

            if( minor < 0 )
                throw new ArgumentOutOfRangeException( nameof( minor ) );

            if( patch < 0 )
                throw new ArgumentOutOfRangeException( nameof( patch ) );

            Major_ = major;
            Minor_ = minor;
            Patch_ = patch;
            PreReleaseParts_ = preReleaseParts ?? new string[0];
            BuildMetadata_ = metadataParts ?? new string[0];
            
            // Validate each part conforms to an "identifier" as defined by the spec
            if(!ValidateIdentifierParts( PreReleaseParts_ ) )
                throw new ArgumentException( "Invalid identifier for pre-release part", nameof( preReleaseParts ) );

            if( !ValidateIdentifierParts( BuildMetadata_ ) )
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

            return Equals( (SemanticVersion)obj );
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
                throw new ArgumentException();

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
            for( var i =0; i< partCount; ++i )
            {
                // rule 3.c
                retVal = string.Compare( PreReleaseParts[ i ], other.PreReleaseParts[ i ], StringComparison.Ordinal );
                if( retVal == 0 )
                    continue;

                // Rule 3.a
                int left,right;
                if( !int.TryParse( PreReleaseParts[i], out left )
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

        /// <summary>Indicates if this version is a development version (e.g. Major Version == 0 )</summary>
        public bool IsDevelopment { get { return Major_ == 0; } }

        /// <summary>Indicates if this version is a pre-release version (e.g. IsDevelopment or Has pre-release parts following the Patch)</summary>
        public bool IsPrerelease { get { return IsDevelopment || PreReleaseParts.Count > 0; } }

        /// <summary>Indicates if this is a valid version</summary>
        public bool IsValid { get { return Major_ >= 0 && Minor_ >=0 && Patch_ >= 0; } }

        /// <summary>Major version number</summary>
        public int Major { get { return Major_; } }
        private readonly int Major_;

        /// <summary>Minor version number</summary>
        public int Minor { get { return Minor_; } }
        private readonly int Minor_;

        /// <summary>Patch version number</summary>
        public int Patch { get { return Patch_; } }
        private readonly int Patch_;

        /// <summary>List of identifier parts forming the pre-release value</summary>
        /// <remarks>
        /// Pre-release values are optional and follow the patch with a '-'. The pre-release
        /// value can consist of multiple parts separated by a '.', this list contains the
        /// individual parts without the leading '-' or separating '.'. 
        /// </remarks>
        public IReadOnlyList<string> PreReleaseParts 
        { 
            get
            {
                if( PreReleaseParts_ == null )
                    return new string[ 0 ];

                return Array.AsReadOnly( PreReleaseParts_  );
            }
        }
        private readonly string[ ] PreReleaseParts_;

        /// <summary>List of identifier parts forming the build Metadata value</summary>
        /// <remarks>
        /// Metadata values are optional and follow the patch with a '+'. The Metadata
        /// value can consist of multiple parts separated by a '.', this list contains
        /// the individual parts without the leading '+' or separating '.'. 
        /// </remarks>
        public IReadOnlyList<string> BuildMetadata
        { 
            get
            {
                if( BuildMetadata_ == null )
                    return new string[ 0 ];

                return Array.AsReadOnly( BuildMetadata_ );
            }
        }
        private readonly string[ ] BuildMetadata_;

        /// <inheritdoc/>
        public override string ToString( )
        {
            return ToString( true );
        }

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
                
            if( BuildMetadata.Count > 0 && includeBuildMetadata)
            {
                bldr.Append( '+' );
                bldr.Append( string.Join( ".", BuildMetadata ) );
            }

            return bldr.ToString();
        }

        /// <summary>Parse a semantic version string into it's component parts</summary>
        /// <param name="versionString">String containing the version to parse</param>
        /// <returns>Parsed version details</returns>
        public static SemanticVersion Parse( string versionString )
        {
            return Parse( versionString, false );
        }

        /// <summary>Parse a semantic version string into it's component parts</summary>
        /// <param name="versionString">String containing the version to parse</param>
        /// <param name="patchOptional">Flag indicating non-standard optional default (0) for the patch if not present</param>
        /// <returns>Parsed version details</returns>
        /// <remarks>
        /// This overload of Parse allows for a non-standard version where the Patch value
        /// defaults to 0 if not present, instead of triggering an exception.
        /// </remarks>
        public static SemanticVersion Parse( string versionString, bool patchOptional )
        {
            var match = SemVersionRegEx.Match( versionString );
            if( !match.Success )
                throw new FormatException();
            
            var major = int.Parse( match.Groups["Major"].Value );
            var minor = int.Parse( match.Groups["Minor"].Value );
            int patch = 0;
            var patchGroup =  match.Groups["Patch"];
            if( !patchOptional || patchGroup.Success )
                patch = int.Parse( patchGroup.Value );

            var preReleaseGroup = match.Groups["PreRelease"];
            var preReleaseParts = new string[ 0 ];
            if( preReleaseGroup.Success )
                preReleaseParts = preReleaseGroup.Value.Split( '.' );

            var metadataGroup = match.Groups["Metadata"];
            var metadataParts = new string[ 0 ];
            if( metadataGroup.Success )
                metadataParts = metadataGroup.Value.Split( '.' );

            return new SemanticVersion( major, minor, patch, preReleaseParts, metadataParts );
        }

        /// <summary>Attempts to parse a version string into a new SemanticVersion instance</summary>
        /// <param name="versionString">String to parse</param>
        /// <param name="version">Version instance to construct</param>
        /// <returns>true if the string is a valid semantic version string that was successfully parsed into <paramref name="version"/></returns>
        public static bool TryParse( string versionString, out SemanticVersion version )
        {
            version = new SemanticVersion();
            var match = SemVersionRegEx.Match( versionString );
            if( !match.Success )
                return false;
            
            int major,minor,patch;

            if( !int.TryParse( match.Groups["Major"].Value, out major ) )
                return false;

            if( !int.TryParse( match.Groups["Minor"].Value, out minor ) )
                return false;

            if( !int.TryParse( match.Groups["Patch"].Value, out patch ) )
                return false;

            var preReleaseGroup = match.Groups[ "PreRelease" ];
            var preReleaseParts = new string[ 0 ];
            if( preReleaseGroup.Success )
                preReleaseParts = preReleaseGroup.Value.Split( '.' );

            var metadataGroup = match.Groups[ "Metadata" ];
            var metadataParts = new string[ 0 ];
            if( metadataGroup.Success )
                metadataParts = metadataGroup.Value.Split( '.' );

            version = new SemanticVersion(major, minor, patch, preReleaseParts, metadataParts );
            return true;
        }

        /// <summary>Compares two <see cref="SemanticVersion"/> instances for equality</summary>
        /// <param name="lhs">Left hand side of the comparison</param>
        /// <param name="rhs">Right hand side of the comparison</param>
        /// <returns><see langword="true"/> if the two versions are equivalent</returns>
        public static bool operator==(SemanticVersion lhs, SemanticVersion rhs)
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

        private static bool ValidateIdentifierParts( IEnumerable< string > metadataParts )
        {
            var q = from part in metadataParts
                    let match = IdentifierRegEx.Match( part )
                    where !match.Success || match.Index != 0 || match.Length != part.Length
                    select part;
            return !q.Any();
        }

        private int ComputeHashCode()
        {
            return ToString( false ).GetHashCode( );
        }
        
        // this is intentionally not a read-only field
        // its a private field and used like a C++ mutable.
        // It caches the HashCode that's expensive to compute
        // so it is only done once.
        private int? HashCode;

        private static readonly Regex IdentifierRegEx = new Regex("[1-9A-Za-z-][0-9A-Za-z-]*");

        // see: http://semver.org/
        // Semantic version is:
        // Major'.'Minor'.'Patch('-'Identifier('.'Identifier)*)?('+'Identifier('.'Identifier)*)?
        // Where Major,Minor and Patch match 0|[1-9][0-9]* (0 or a non-leading zero sequence of digits)
        // Identifier is a sequence of ASCII alphanumerics or '-' without a leading 0
        // the - signifies the pre-release information and impacts precedence if present
        // the + signifies the build meta data and has no impact on precedence
        private const string SemVerRegExPattern = "(?<Major>(0|[1-9][0-9]*))"
                                                + @"\.(?<Minor>(0|[1-9][0-9]*))"
                                                + @"(\.(?<Patch>(0|[1-9][0-9]*)))?"
                                                + @"(-(?<PreRelease>[1-9A-Za-z-][0-9A-Za-z-]*(\.[1-9A-Za-z-][0-9A-Za-z-]*)*))?"
                                                + @"(\+(?<Metadata>[1-9A-Za-z-][0-9A-Za-z-]*(\.[1-9A-Za-z-][0-9A-Za-z-]*)*))?";
        private static readonly Regex SemVersionRegEx = new Regex(SemVerRegExPattern);
    }
}