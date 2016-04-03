using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CMSIS.Pack
{
    /// <summary>Contains the contents of a CMSIS-Pack index</summary>
    /// <remarks>
    /// The source of the index content may be loaded from a file, a URL
    /// or provided programatically to the constructor.
    /// </remarks>
    public class PackIndex
    {
        /// <summary>Default URI for the pack index</summary>
        public const string DefaultIndexUriPath = "http://www.keil.com/pack/index.idx";

        public PackIndex( )
        {
        }

        public PackIndex( IEnumerable<IPackIndexEntry> packs )
        {
            Packs_.AddRange( packs );
        }

        /// <summary>Enumeration of the Packs listed in the Index</summary>
        public IEnumerable<IPackIndexEntry> Packs => Packs_.AsReadOnly( );
        private readonly List<IPackIndexEntry> Packs_ = new List<IPackIndexEntry>();

        /// <summary>Download and parse the index file from the Default location <see cref="DefaultIndexUriPath"/></summary>
        /// <returns>Task for the Asynchronous operation</returns>
        public Task LoadAsync( ) => LoadAsync( new Uri( DefaultIndexUriPath ) );

        public Task LoadAsync( IProgress<FileDownloadProgress> progressSink ) => LoadAsync( new Uri( DefaultIndexUriPath ), progressSink );

        /// <summary>Download and parse the index asynchronously from a URL</summary>
        /// <param name="indexUrl">URL of the index file to download</param>
        /// <returns>Task for the Asynchronous operation</returns>
        public async Task LoadAsync( Uri indexUrl )
        {
            using( var client = new HttpClient( ) )
            {
                var content = await client.GetStringAsync( indexUrl );
                await ParseAsync( content );
            }
        }

        /// <summary>Asynchronously read and parse the index from a file</summary>
        /// <param name="filePath">Path of the file to load and parse</param>
        /// <returns>Task for the Asynchronous operation</returns>
        public async Task LoadAsync( string filePath )
        {
            if( string.IsNullOrWhiteSpace( filePath ) )
                throw new ArgumentException( "Path cannot be null or empty", nameof( filePath ) );

            if( !File.Exists( filePath ) )
                throw new FileNotFoundException( filePath );

            var content = await Task.Run( ()=>File.ReadAllText( filePath ) );
            await ParseAsync( content );
        }

        public Task LoadAsync( Uri uri, IProgress<FileDownloadProgress> progressSink )
        {
            using( var webClient = new WebClient() )
            {
                var sw = new Stopwatch();
                webClient.DownloadFileCompleted += ( s, e ) => progressSink.Report( new FileDownloadProgress( uri, sw.Elapsed, -1, -1 ) );
                webClient.DownloadProgressChanged += ( s, e ) => progressSink.Report( new FileDownloadProgress( uri, sw.Elapsed, e.BytesReceived, e.TotalBytesToReceive ) );
                sw.Start( );
                return webClient.DownloadFileTaskAsync( uri.Host, uri.LocalPath );
            }
        }

        /// <summary>Asynchronously save the index file to the specified file location</summary>
        /// <param name="filePath">Path of the file to save to</param>
        /// <returns>Task for the Asynchronous operation</returns>
        public Task SaveAsync( string filePath )
        {
            if( string.IsNullOrWhiteSpace( filePath ) )
                throw new ArgumentException( "Path cannot be null or empty", nameof( filePath ) );

            return Task.Run( ( ) =>
            {
                var dir = Path.GetDirectoryName( filePath );
                if( dir != null )
                {
                    if( !Directory.Exists( dir ) )
                        Directory.CreateDirectory( dir );
                }

                File.WriteAllText( filePath, Content );
            } );
        }

        /// <summary>Parses the contents of an index file</summary>
        /// <param name="indexContent">contents of a CMSIS-PACK index file</param>
        /// <returns>Task for the Asynchronous operation</returns>
        public Task ParseAsync( string indexContent )
        {
            Packs_.Clear( );
            Content = indexContent;

            return Task.Run( ()=>
            {
                var settings = new XmlReaderSettings
                    { IgnoreComments = true
                    , IgnoreProcessingInstructions = true
                    , ConformanceLevel = ConformanceLevel.Fragment
                    };

                using( var strm = new StringReader( indexContent ) )
                using( var rdr = XmlReader.Create( strm, settings ) )
                {
                    // Despite having an xml doc processing instruction the index file is *NOT*
                    // valid XML. It has multiple pdsc elements at the root, which is invalid
                    // XML. This deals with that by reading the nodes individually rather than
                    // as a whole document.
                    //
                    // skip past the XML declaration and move to the first pdsc element
                    rdr.Read( );
                    rdr.ReadToFollowing( "pdsc" );
                    while( rdr.ReadState != ReadState.EndOfFile )
                    {
                        var pdsc = ( XElement )XNode.ReadFrom( rdr );
                        var pack = new PackIndexEntry( pdsc.Attribute( "url" ).Value
                                                     , pdsc.Attribute( "name" ).Value
                                                     , pdsc.Attribute( "version" ).Value
                                                     );

                        Packs_.Add( pack );
                        rdr.ReadToFollowing( "pdsc" );
                    }
                }
            });
        }

        private string Content;
    }
}
