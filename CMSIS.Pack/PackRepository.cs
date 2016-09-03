using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMSIS.Pack
{
    /// <summary>CMSIS-Pack repository</summary>
    /// <remarks>
    /// <para>A repository consists of a local cache and source URI to download
    /// new packages from. Packs are installed into the Local cache after
    /// they are downloaded.</para>
    /// <para>The repository contains an index of all available packs, which is
    /// downloaded from the source and parsed.</para>
    /// </remarks>
    public class PackRepository
        : IRepository
        , IDisposable
    {
        /// <summary>Constructs a new <see cref="PackRepository"/></summary>
        /// <param name="source">Uri of the source repository to download files from</param>
        /// <param name="localPath">Full path of the local repository</param>
        public PackRepository( Uri source, string localPath )
        {
            SourceUri = source;
            LocalPath = localPath;
            WebRoot = Path.Combine( LocalPath, ".Web" );
            DownloadRoot = Path.Combine( LocalPath, ".Download" );
            PackIdxWatcher = new FileSystemWatcher( LocalPath, "pack.idx" );
            PackIdxWatcher.Changed += ( s, e ) => Updated( this, new RepositoryUpdateEventArgs( ) );
        }

        /// <summary>Last time the repository's index was updated</summary>
        public DateTime LastUpdatedTimeUTC
        {
           get
           {
                var path = RepositoryIndexPath;
                if( File.Exists( path ) )
                    return File.GetLastWriteTimeUtc( RepositoryIndexPath );
                else
                    return new DateTime( );
           }
        }

        public string WebRoot { get; }

        public string DownloadRoot { get; }

        public Uri SourceUri { get; }

        public string LocalPath { get; }

        public string RepositoryIndexPath => Path.Combine( LocalPath, "pack.idx" );

        public string DownloadIndexPath => Path.Combine( WebRoot, "index.idx" );

        public event EventHandler<RepositoryUpdateEventArgs> Updated = delegate { };

        public IEnumerable<IRepositoryPackage> Packs => Packs_.AsEnumerable( );
        private List<IRepositoryPackage> Packs_;

        public Task DownloadAsync( IRepositoryPackage package, IProgress<FileDownloadProgress> progressSink )
        {
            throw new NotImplementedException( );
        }

        public Task InstallPack( IRepositoryPackage package, IProgress<PackInstallProgress> progressSink )
        {
            // unzip the package into the appropriate location in the local path
            throw new NotImplementedException( );
        }

        public async Task LoadFromLocalAsync()
        {
            Updated( this, new RepositoryUpdateEventArgs( RepositoryState.DownloadingIndex, null ) );
            Packs_ = new List<IRepositoryPackage>( );
            var index = new PackIndex( );
            await index.LoadAsync( DownloadIndexPath );
            foreach( var pack in index.Packs )
            {
                var repositoryPack = new RepositoryPackage( this, pack, await GetInstallStateAsync( pack ) );
                Packs_.Add( repositoryPack );
            }
        }

        public Task UpdateLocalFromSourceAsync( ) => Task.FromResult<object>( null );

        private Task<PackInstallState> GetInstallStateAsync( IPackIndexEntry pack )
        {
            return Task.Run( ( ) =>
            {
                var retVal = PackInstallState.AvailableForDownload;
                if( File.Exists( Path.Combine( DownloadRoot, pack.PackName ) ) )
                    retVal = PackInstallState.Downloaded;

                if( File.Exists( Path.Combine( LocalPath, pack.LocalPath, pack.PdscName ) ) )
                    retVal = PackInstallState.Installed;

                return retVal;
            } );
        }

        private readonly FileSystemWatcher PackIdxWatcher;

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose( bool disposing )
        {
            if( !disposedValue )
            {
                if( disposing )
                {
                    PackIdxWatcher.Dispose( );
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

#if PackRepository_HAS_FINALIZER
        // ~PackRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }
#endif
        // This code added to correctly implement the disposable pattern.
        public void Dispose( )
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose( true );

#if PackRepository_HAS_FINALIZER
            GC.SuppressFinalize(this);
#endif
        }
#endregion
    }
}
