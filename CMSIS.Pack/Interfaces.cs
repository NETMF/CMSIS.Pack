using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CMSIS.Pack.PackDescription;

namespace CMSIS.Pack
{
    public enum PackInstallState
    {
        AvailableForDownload,
        Downloading,
        Downloaded,
        Installing,
        Installed,
    }

    public interface IPackIndexEntry
    {
        /// <summary>File name of the compressed form of this pack</summary>
        /// <remarks>
        /// The file name is of the form: VENDOR.NAME.VERSION.pack
        /// </remarks>
        string PackName { get; }

        /// <summary>Vendor name parsed out of the PackName from the index</summary>
        string Vendor { get; }

        /// <summary>Name of the pack parsed out of the Pack name from the index</summary>
        string Name { get; }

        /// <summary>Name of the PDSC file for this pack</summary>
        /// <remarks>
        /// The PDSC filename takes the form: VENDOR.NAME.pdsc
        /// </remarks>
        string PdscName { get; }

        /// <summary>Full URL of the Package Description (PDSC) file for this pack</summary>
        Uri PdscUrl { get; }

        /// <summary>FULL URL of the Package file for this pack</summary>
        Uri PackUrl { get; }

        /// <summary>Base URI for this pack read from the index</summary>
        Uri Url { get; }
        
        /// <summary>Local path name for this pack relative to the root of a repository</summary>
        /// <remarks>
        /// The local path takes the form VENDOR\NAME\VERSION
        /// </remarks>
        string LocalPath { get; }

        /// <summary>Version of the pack</summary>
        SemanticVersion Version { get; }

        /// <summary>Retrieves the contents of the Package Description file</summary>
        /// <returns>string containing the XML content of the description</returns>
        Task<string> GetPackageDescriptionDocumentAsync( );

        /// <summary>Asynchronously download and parse the package description file for this pack</summary>
        /// <returns>parsed package instance for the package description</returns>
        Task<Package> GetPackageDescriptionAsync( );
    }

    public interface IRepositoryPackage
        : IPackIndexEntry
    {
        PackInstallState InstallState { get; }
        IRepository Repository { get; }

        Task Download( IProgress<FileDownloadProgress> progressSink );
        
        Task InstallPack( IProgress<PackInstallProgress> progressSink );
    }

    public enum RepositoryState
    {
        Idle,
        DownloadingIndex,
        DownloadingIndexPdsc,
        DownloadingPackPdsc,
        DownloadingPack,
        InstallingPack,
        UninstallingPack,
        DeletingPack
    }

    /// <summary>Represents a remote repository and local store of the installed pack files</summary>
    public interface IRepository
    {
        /// <summary>Location of the source of packs to download from</summary>
        Uri SourceUri { get; }

        /// <summary>Location of the locally installed packs that updates and new packs are installed into</summary>
        string LocalPath { get; }

        DateTime LastUpdatedTimeUTC { get; }
        /// <summary>Full path to the local ".Web" folder containing the pack descriptions cached from the web source</summary>
        string WebRoot { get; }

        /// <summary>Full path </summary>
        string DownloadRoot { get; }

        IEnumerable<IRepositoryPackage> Packs { get; }

        event EventHandler<RepositoryUpdateEventArgs> Updated;
        
        Task UpdateLocalFromSource( );
        
        Task LoadFromLocal( );
        
        Task Download( IRepositoryPackage package, IProgress<FileDownloadProgress> progressSink );

        Task InstallPack( IRepositoryPackage package, IProgress<PackInstallProgress> progressSink );
    }
}
