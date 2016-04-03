using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using CMSIS.Pack.PackDescription;

namespace CMSIS.Pack
{
    /// <summary>Reference to a CMSIS-PACK</summary>
    /// <remarks>
    /// Packs are listed in a published index (index.idx)
    /// this class represents a single entry in the
    /// index.
    /// </remarks>
    public class PackIndexEntry 
        : IPackIndexEntry
    {
        /// <summary>Creates a new PackIndexEntry from data read out of the index</summary>
        /// <param name="descriptorUri">Base URI for the pack</param>
        /// <param name="packDescriptiorFileName">Name of the pack in VENDOR.NAME form</param>
        /// <param name="packVersion">Pack version (in semantic Version 2.0 form)</param>
        public PackIndexEntry( string descriptorUri, string packDescriptiorFileName, string packVersion )
        {
            if( string.IsNullOrWhiteSpace( descriptorUri ) )
                throw new ArgumentException( "Non empty string required", nameof( descriptorUri ) );

            if( string.IsNullOrWhiteSpace( packDescriptiorFileName ) )
                throw new ArgumentException( "Non empty string required", nameof( packDescriptiorFileName ) );

            if( string.IsNullOrWhiteSpace( packVersion ) )
                throw new ArgumentException( "Non empty string required", nameof( packVersion ) );

            Url = CreateUriWithTrailingSeperator( descriptorUri );
            PdscName = packDescriptiorFileName;
            var parts = PdscName.Trim().Split( '.' );
            if( parts.Length != 3 )
                throw new ArgumentException( "Invalid pack name format", nameof( packDescriptiorFileName ) );

            PackName = Path.ChangeExtension( PdscName, Version + ".pack" );
            PdscUrl = new Uri( Url, PdscName );
            PackUrl = new Uri( Url, PackName );

            Vendor = parts[ 0 ];
            Name = parts[ 1 ];
            SemanticVersion version;
            if( !SemanticVersion.TryParse( packVersion, out version ) )
                throw new ArgumentException( "Invalid semantic version provided", nameof( packVersion ) );
            Version = version;
            LocalPath = Path.Combine( Vendor, Name, Version.ToString( ) );
         }

        /// <summary>File name of the pack file this reference is for</summary>
        /// <remarks>
        /// The file name is of the form: VENDOR.NAME.VERSION.pack
        /// </remarks>
        public string PackName { get; }

        /// <summary>Vendor name parsed out of the PackName from the index</summary>
        public string Vendor { get; }
        
        /// <summary>Name of the pack parsed out of the Pack name from the index</summary>
        public string Name { get; }
        
        /// <summary>Name of the PDSC file for this pack</summary>
        /// <remarks>
        /// The PDSC filename takes the form: VENDOR.NAME.pdsc
        /// </remarks>
        public string PdscName { get; }
        
        /// <summary>Full URL of the Package Description (PDSC) file for this pack</summary>
        public Uri PdscUrl { get; }

        /// <summary>FULL URL of the Package file for this pack</summary>
        public Uri PackUrl { get; }
        
        /// <summary>Base URI for this pack read from the index</summary>
        public Uri Url { get; }
        
        /// <summary>Version of the pack</summary>
        public SemanticVersion Version { get; }

        /// <summary>Relative path for the pack in the local repository in VENDOR\NAME\VERSION form</summary>
        public string LocalPath { get; }

        /// <summary>Retrieves the contents of the Package Description file</summary>
        /// <returns>string containing the XML content of the description</returns>
        public async Task<string> GetPackageDescriptionDocumentAsync()
        {
            using( var client = new HttpClient( ) )
            {
                client.BaseAddress = Url;
                return await client.GetStringAsync( PdscName );
            }
        }

        /// <summary>Asynchronously download and parse the package description file for this pack</summary>
        /// <returns>parsed package instance for the package description</returns>
        public async Task<Package> GetPackageDescriptionAsync( )
        {
            var xml = await GetPackageDescriptionDocumentAsync( );
            return await Package.ParseAsync( xml );
        }

        private static Uri CreateUriWithTrailingSeperator( string descriptorUri )
        {
            var baseUri = new UriBuilder( descriptorUri );
            baseUri.Path = baseUri.Path.TrimEnd( '\\' );
            baseUri.Path = baseUri.Path.TrimEnd( '/' );
            baseUri.Path = baseUri.Path + '/';

            return baseUri.Uri;
        }
    }
}
