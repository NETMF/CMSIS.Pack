using System;
using System.IO;
using System.Threading.Tasks;
using CMSIS.Pack.PackDescription;
using SemVer.NET;

namespace CMSIS.Pack
{
    class RepositoryPackage
        : IRepositoryPackage
    {
        internal RepositoryPackage( IRepository repository, IPackIndexEntry details, PackInstallState installState )
        {
            if( repository == null )
                throw new ArgumentNullException( nameof( repository ) );

            if( details == null )
                throw new ArgumentNullException( nameof( details ) );

            Repository = repository;
            Details = details;
            InstallState = installState;
        }

        public IPackIndexEntry Details { get; }

        public IRepository Repository { get; }

        public PackInstallState InstallState { get; private set; }
        
        public string PackName => Details.PackName;
        public string Vendor => Details.Vendor;
        public string Name => Details.Name;
        public string PdscName => Details.PdscName;
        public Uri PdscUrl => Details.PdscUrl;
        public Uri PackUrl => Details.PackUrl;
        public Uri Url => Details.Url;
        public string LocalPath => Details.LocalPath;
        public SemanticVersion Version => Details.Version;

        public async Task<string> GetPackageDescriptionDocumentAsync( )
        {
            var path = Path.Combine( Repository.WebRoot, PdscName );
            if( !File.Exists( path ) )
            {
                // download the PDSC file to the repo's .Web location
                var retVal = await Details.GetPackageDescriptionDocumentAsync( );
                if( !string.IsNullOrWhiteSpace( retVal ) )
                {
                    File.WriteAllText( path, retVal );
                }
                return retVal;
            }

            using( var strm = File.OpenText( path ) )
            {
                return await strm.ReadToEndAsync( );
            }
        }

        public async Task<Package> GetPackageDescriptionAsync( )
        {
            string content = await GetPackageDescriptionDocumentAsync( );
            if( string.IsNullOrWhiteSpace( content ) )
            {
                return null;
            }
            return await Package.ParseAsync( content );
        }

        public async Task DownloadAsync( IProgress<FileDownloadProgress> progressSink )
        {
            if( InstallState == PackInstallState.Downloaded )
                return;
            
            if( InstallState != PackInstallState.AvailableForDownload )
                throw new InvalidOperationException( );

            InstallState = PackInstallState.Downloading;
            try
            {
                await Repository.DownloadAsync( this, progressSink );
            }
            catch
            {
                InstallState = PackInstallState.AvailableForDownload;
                throw;
            }
            InstallState = PackInstallState.Downloaded;
        }

        public async Task InstallPackAsync( IProgress<PackInstallProgress> progressSink )
        {
            if( InstallState == PackInstallState.Installed )
                return;

            if( InstallState != PackInstallState.Downloaded )
                throw new InvalidOperationException( );

            InstallState = PackInstallState.Installing;
            try
            {
                await Repository.InstallPack( this, progressSink );
            }
            catch
            {
                InstallState = PackInstallState.Downloaded;
                throw;
            }
            InstallState = PackInstallState.Downloaded;
        }
    }
}
