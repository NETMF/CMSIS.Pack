using System;
using System.IO;
using System.Threading.Tasks;
using CMSIS.Pack.PackDescription;

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
            Details_ = details;
            InstallState = installState;
        }

        public IPackIndexEntry Details
        {
            get { return Details_; }
        }
        private readonly IPackIndexEntry Details_;

        public IRepository Repository { get; private set; }

        public PackInstallState InstallState { get; private set; }
        
        public string PackName
        {
            get { return Details_.PackName; }
        }

        public string Vendor
        {
            get { return Details_.Vendor; }
        }

        public string Name
        {
            get { return Details_.Name; }
        }

        public string PdscName
        {
            get { return Details_.PdscName; }
        }

        public Uri PdscUrl
        {
            get { return Details_.PdscUrl; }
        }

        public Uri PackUrl
        {
            get { return Details_.PackUrl; }
        }

        public Uri Url
        {
            get { return Details_.Url; }
        }

        public string LocalPath
        {
            get { return Details_.LocalPath; }
        }

        public SemanticVersion Version
        {
            get { return Details_.Version; }
        }

        public async Task<string> GetPackageDescriptionDocumentAsync( )
        {
            using( var strm = File.OpenText( Path.Combine( Repository.WebRoot, PdscName ) ) )
            {
                return await strm.ReadToEndAsync( );
            }
        }

        public async Task<Package> GetPackageDescriptionAsync( )
        {
            string content = await GetPackageDescriptionDocumentAsync( );
            return await Package.ParseFromAsync( content );
        }

        public async Task Download( IProgress<FileDownloadProgress> progressSink )
        {
            if( InstallState == PackInstallState.Downloaded )
                return;
            
            if( InstallState != PackInstallState.AvailableForDownload )
                throw new InvalidOperationException( );

            InstallState = PackInstallState.Downloading;
            try
            {
                await Repository.Download( this, progressSink );
            }
            catch
            {
                InstallState = PackInstallState.AvailableForDownload;
                throw;
            }
            InstallState = PackInstallState.Downloaded;
        }

        public async Task InstallPack( IProgress<PackInstallProgress> progressSink )
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
