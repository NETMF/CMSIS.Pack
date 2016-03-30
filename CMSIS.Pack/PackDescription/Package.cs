using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CMSIS.Pack.PackDescription
{
    // Unfortunately the officially published schema has circular group definitions
    // that XSD.exe can't handle. Furthermore, some of the officially posted and
    // "validated"  PDSC files don't conform to the schema. In particular, they
    // have the following issues:
    //    1) They use DVendor attributes with values that don't match the case
    //       of the official schema XSD and documentation.
    //    2) They have feature[@n] using a scaled integer notation (i.e. "512K")
    //    3) Date values are occasionally missing leading 0 digits to match official
    //       XSD:date types. (i.e. "2015-12-1" should be "2015-12-01")
    //
    // This class and related classes work around these issues by Manually handling
    // the deserialization and processing the offending nodes more liberally.
    public class Package
    {
        public Package(  )
        {
            Releases = new List<Release>();
            Keywords = new List<string>();
            Generators = new List<Generator>();
            Devices = new List<DeviceFamily>();
            Boards = new List<Board>();
            Taxonomy = new List<TaxonomyDescription>();
            Apis = new List<Api>();
            Conditions = new List<Condition>();
            Examples = new List<Example>();
            Components = new List<Component>();
        }

        public SemanticVersion SchemaVersion { get; set; }
        public string Vendor { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Uri Url {get; set; }
        public string SupportContact { get; set; }
        public string License { get; set; }

        public IList<Release> Releases { get; }
        public IList<string> Keywords { get; }
        public IList<Generator> Generators { get; }
        public IList<DeviceFamily> Devices { get; }
        public IList<Board> Boards { get; }
        public IList<TaxonomyDescription> Taxonomy { get; }
        public IList<Api> Apis { get; }
        public IList<Condition> Conditions { get; }
        public IList<Example> Examples { get; }
        public IList<Component> Components { get; }

        public static async Task<Package> LoadFromAsync( string uri )
        {
            if( string.IsNullOrWhiteSpace( uri ) )
                throw new ArgumentException("Path is null or empty", nameof( uri ) );

            var doc = await Task.Run( ()=> XDocument.Load( uri ) );
            return await ParseFromAsync( doc );
        }

        public static async Task<Package> ParseFromAsync( string xml )
        {
            var doc = await Task.Run( ( ) => XDocument.Parse( xml ) );
            return await ParseFromAsync( doc );
        }

        public static Task<Package> ParseFromAsync( XDocument doc )
        {
            return Task.Run( ( ) =>
            {
                var retVal = new Package( );
                var pkgElement = doc.Element( ElementNames.Package );

                retVal.Name = pkgElement.Element( ElementNames.Name ).Value;
                retVal.Vendor = pkgElement.Element( ElementNames.Vendor ).Value;
                retVal.Description = pkgElement.Element( ElementNames.Description ).Value;
                retVal.Url = new Uri( pkgElement.Element( ElementNames.Url ).Value );
                retVal.SupportContact = pkgElement.Element( ElementNames.SupportContact )?.Value;
                retVal.License = pkgElement.Element( ElementNames.License )?.Value;

                pkgElement.Element( ElementNames.Releases   ).ParseCollectionElements( ElementNames.Release    , retVal.Releases  , Release.ParseFrom );
                pkgElement.Element( ElementNames.Keywords   ).ParseCollectionElements( ElementNames.Keyword    , retVal.Keywords  , Keyword.ParseFrom );
                pkgElement.Element( ElementNames.Generators ).ParseCollectionElements( ElementNames.Generator  , retVal.Generators, Generator.ParseFrom );
                pkgElement.Element( ElementNames.Devices    ).ParseCollectionElements( ElementNames.Family     , retVal.Devices   , DeviceFamily.ParseFrom );
                pkgElement.Element( ElementNames.Boards     ).ParseCollectionElements( ElementNames.Board      , retVal.Boards    , Board.ParseFrom );
                pkgElement.Element( ElementNames.Taxonomy   ).ParseCollectionElements( ElementNames.Description, retVal.Taxonomy  , TaxonomyDescription.ParseFrom );
                pkgElement.Element( ElementNames.Apis       ).ParseCollectionElements( ElementNames.Api        , retVal.Apis      , Api.ParseFrom );
                pkgElement.Element( ElementNames.Conditions ).ParseCollectionElements( ElementNames.Condition  , retVal.Conditions, Condition.ParseFrom );
                pkgElement.Element( ElementNames.Examples   ).ParseCollectionElements( ElementNames.Example    , retVal.Examples  , Example.ParseFrom );
                pkgElement.Element( ElementNames.Components ).ParseCollectionElements( ElementNames.Component  , retVal.Components, Component.ParseFrom );
                // TODO: figure out plan to deal with multiple child element types in components element (component, bundle)

                return retVal;
            } );
        }
    }
}
