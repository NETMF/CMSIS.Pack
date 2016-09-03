using CMSIS.Pack;
using Microsoft.Win32;
using System.IO;
using System;

namespace CMSIS.Pack
{
    public interface IRepositoryProvider
    {
        /// <summary>Name of the provider</summary>
        string Name { get; }

        /// <summary>Full path to the folder containing the repository</summary>
        IRepository Repository { get; }
    }

    /// <summary>Repository location provider for standard ARM/Keil MDK Installations</summary>
    /// <remarks>
    /// Eventually this should be "discovered" via MEF by the CMSIS.Pack system so that
    /// applications don't need to know where repositories come from and providing a
    /// common way to enumerate options to display for the user to choose.
    /// </remarks>
    public class MDKRepositoryProvider
        : IRepositoryProvider
    {
        /// <summary>Default URI for the pack index</summary>
        public const string DefaultIndexUriPath = "http://www.keil.com/pack/index.idx";

        public MDKRepositoryProvider()
        {
            using( var hklm = RegistryKey.OpenBaseKey( RegistryHive.LocalMachine, RegistryView.Registry32 ) )
            using( var key = hklm.OpenSubKey( MDKInstallKey ) )
            {
                Path = key.GetValue( "Path" ) as string;
                Version = key.GetValue( "Version" ) as string;
                var repoPath = System.IO.Path.Combine( Path, "Pack" );
                PackRepositoryPath = Directory.Exists( repoPath ) ? repoPath : null;
                Repository = new PackRepository( new Uri( DefaultIndexUriPath ), PackRepositoryPath );
            }
        }

        public string Path { get; }
        public string Version { get; }
        public string PackRepositoryPath { get; }

        public string Name => $"MDK {Version}";

        public IRepository Repository { get; }

        private const string MDKInstallKey = @"SOFTWARE\Keil\Products\MDK";
    }
}
