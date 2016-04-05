using CMSIS.Pack;
using GalaSoft.MvvmLight;
using System;
using System.Threading.Tasks;
using CMSIS.Pack.PackDescription;
using SemVer.NET;

namespace NetmfPackInstaller
{
    public enum PackReferenceState
    {
        Initialized,
        DownloadingPdsc,
        Ready
    }

    public class PackReferenceViewModel 
        : ViewModelBase
    {
        public PackReferenceViewModel( IRepositoryPackage packRef )
        {
            if( packRef == null )
                throw new ArgumentNullException( nameof( packRef ) );
            
            PackageRef = packRef;
            State = PackReferenceState.Initialized;
        }

        public async Task LoadAndParseDescriptionAsync( )
        {
            State = PackReferenceState.DownloadingPdsc;

            // get the PDSC async, parse to get description
            PackageDescription = await PackageRef.GetPackageDescriptionAsync( );
            State = PackReferenceState.Ready;
        }

        public PackReferenceState State
        {
            get { return State__; }
            private set
            {
                State__ = value;
                RaisePropertyChanged( );
            }
        }
        private PackReferenceState State__;

        public SemanticVersion Version => PackageRef.Version;
        public string Name => PackageRef.Name;
        public string Vendor =>  PackageRef.Vendor;
        public string Description => PackageDescription?.Description ?? string.Empty;
        public PackInstallState InstallState => PackageRef.InstallState;

        private readonly IRepositoryPackage PackageRef;
        private Package PackageDescription;
    }
}