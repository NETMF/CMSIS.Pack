using System;
using System.Collections.Generic;

namespace SemVer.NET
{
    /// <summary>Parse result of a Version Prerelease or build qualifier</summary>
    public class VersionQualifier
    {
        public VersionQualifier( char leadingChar, IEnumerable<string> identifiers)
        {
            LeadingChar = leadingChar;
            Identifiers = identifiers;
        }

        public char LeadingChar { get; }
        public IEnumerable<string> Identifiers { get; }
    }

    /// <summary>Contains the results of parsing a Semantic version string</summary>
    /// <remarks>
    /// <para>In order to support variations on Semantic versions as well as gracefully
    /// handle publicly released components with errant Semantic Versions this
    /// result contains the captured parts. This allows for more restrictive usage, 
    /// such as found in CSemVer and also can handle simple Major.minor versions
    /// (e.g. without any patch number). Ultimately, it is up to the class consuming
    /// the result to determine the behavior it allows</para>
    /// <para>The numeric parts are left as strings since, technically they can be any
    /// length. Though practically speaking a 32bit integer is generally considered enough.</para>
    /// </remarks>
    public class ParseResult
    {
        /// <summary>Constructs a new semantic version parse Result</summary>
        /// <param name="major">string containing the digits of the major component of the version</param>
        /// <param name="minor">string containing the digits of the minor component of the version</param>
        /// <param name="patch">potentially empty, but not <see langword="null"/>, string containing the digits of the patch component of the version</param>
        /// <param name="prereleaseParts">Collection of strings corresponding to the prerelease identifiers in the version</param>
        /// <param name="buildParts">Collection of strings corresponding to the build metadata  identifiers in the version</param>
        /// <exception cref="ArgumentNullException">If any of the arguments is <see langword="null"/></exception>
        public ParseResult( char? leadingV
                          , string major
                          , string minor
                          , string patch
                          , VersionQualifier prereleaseParts
                          , VersionQualifier buildParts
                          )
        {
            if( major == null )
                throw new ArgumentNullException( nameof( major ) );

            if( minor == null )
                throw new ArgumentNullException( nameof( minor ) );

            if( patch == null )
                throw new ArgumentNullException( nameof( patch ) );

            LeadingV = leadingV;
            Major = major;
            Minor = minor;
            Patch = patch;
            Prerelease = prereleaseParts;
            BuildMetadata = buildParts;
        }

        /// <summary>Gets a potentially <see langword="null"/> leading 'v' or 'V' character</summary>
        /// <remarks>
        /// Technically, a Semantic version number does not include a leading character,
        /// however, many common uses of version numbers use one by convention. This,
        /// can be tested for <see langword="null"/> and trigger an exception if the
        /// leading character is provided but strict conformance to the specification
        /// is required.
        /// </remarks>
        public char? LeadingV { get; }

        /// <summary>Gets a string containing the digits of the Major version number</summary>
        public string Major { get; }

        /// <summary>Gets a string containing the digits of the Minor version number</summary>
        public string Minor { get; }

        /// <summary>Gets a string containing the digits of the Patch version number  or an empty string if none was provided</summary>
        /// <remarks>
        /// Technically, a correct Semantic Version requires the Patch value. However, to gracefully handle
        /// some real world erroneously versioned packages the grammar used in this library treats it as
        /// optional. The consumer, such as <see cref="SemanticVersion"/> can detect if the patch is not
        /// provided by calling <see cref="string.IsNullOrWhiteSpace(string)"/> and throwing an exception
        /// to maintain full compliance with the SemanticVersion specs. A consumer may also elect to allow
        /// the missing patch and apply a sensible default (such as "0") depending on the domain specific
        /// conditions.
        /// </remarks>
        public string Patch { get; }

        /// <summary>Gets a collection of prerelease identifier strings</summary>
        public VersionQualifier Prerelease { get; }
        
        /// <summary>Gets a collection of the build metadata identifier strings</summary>
        public VersionQualifier BuildMetadata { get; }
    }
}