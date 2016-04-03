using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMSIS.Pack
{
    public class PackRepository
        : IRepository
    {
        public PackRepository( Uri source, string localPath )
        {
            SourceUri = source;
            LocalPath = localPath;
            WebRoot = Path.Combine( LocalPath, ".Web" );
            DownloadRoot = Path.Combine( LocalPath, ".Download" );
            PackIdxWatcher = new FileSystemWatcher( LocalPath, "pack.idx" );
            PackIdxWatcher.Changed += ( s, e ) => Updated( this, new RepositoryUpdateEventArgs( ) );
        }
        
        public PackRepository( string localPath )
            : this( new Uri( PackIndex.DefaultIndexUriPath ), localPath )
        {
        }

        public DateTime LastUpdatedTimeUTC => File.GetLastWriteTimeUtc( Path.Combine( LocalPath, "pack.idx" ) );

        public string WebRoot { get; }

        public string DownloadRoot { get; }

        public Uri SourceUri { get; }

        public string LocalPath { get; }

        public event EventHandler<RepositoryUpdateEventArgs> Updated = delegate { };

        public IEnumerable<IRepositoryPackage> Packs => Packs_.AsEnumerable( );
        private List<IRepositoryPackage> Packs_;

        public Task Download( IRepositoryPackage package, IProgress<FileDownloadProgress> progressSink )
        {
            throw new NotImplementedException( );
        }

        public Task InstallPack( IRepositoryPackage package, IProgress<PackInstallProgress> progressSink )
        {
            throw new NotImplementedException( );
        }

        public async Task LoadFromLocal()
        {
            Updated( this, new RepositoryUpdateEventArgs( RepositoryState.DownloadingIndex, null ) );
            Packs_ = new List<IRepositoryPackage>( );
            var index = new PackIndex( );
            await index.LoadAsync( Path.Combine( WebRoot, "index.idx" ) );
            foreach( var pack in index.Packs )
            {
                var repositoryPack = new RepositoryPackage( this, pack, await GetInstallState( pack ) );
                Packs_.Add( repositoryPack );
            }
        }

        public Task UpdateLocalFromSource( ) => Task.FromResult<object>( null );

        private Task<PackInstallState> GetInstallState( IPackIndexEntry pack )
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
    }
}
