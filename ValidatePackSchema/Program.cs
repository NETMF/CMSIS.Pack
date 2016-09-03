#define MERGE_VENDOR_ENUMS
using CMSIS.Pack;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ValidatePackSchema
{

    class Program
    {
        // map of the schema version numbers to the Resource name of the schema file
        static SchemaMap SchemaVersionMap = new SchemaMap
        {
            //                   Version | Schema resource
            new SchemaMapEntry( "1.0"    , "ValidatePackSchema.PACK_1_3_0.xsd" ), // + schema versions prior to 1.3.0 not available on GitHub
            new SchemaMapEntry( "1.2"    , "ValidatePackSchema.PACK_1_3_0.xsd" ), // | nor from Keil.com/pack. Thus, this uses the earliest
            new SchemaMapEntry( "1.1"    , "ValidatePackSchema.PACK_1_3_0.xsd" ), // | available schema for pack descriptions with older schema
            new SchemaMapEntry( "1.3"    , "ValidatePackSchema.PACK_1_3_0.xsd" ), // + version attributes
            new SchemaMapEntry( "1.3.3"  , "ValidatePackSchema.PACK_1_3_3.xsd" ),
            new SchemaMapEntry( "1.4"    , "ValidatePackSchema.PACK_1_4_0.xsd" ),
            new SchemaMapEntry( "1.4.2"  , "ValidatePackSchema.PACK_1_4_2.xsd" ),
            new SchemaMapEntry( "1.4.6"  , "ValidatePackSchema.PACK_1_4_6.xsd" ),
        };

        static IRepositoryProvider RepoProvider = new MDKRepositoryProvider( );

        // This app is used to display the schema validation failures for the
        // descriptions present in an MDK repository's .Web location
        static void Main( string[ ] args )
        {

// workaround buggy in-field PDSC files by re-writing the
// schemas to contain a set of enumerated values for the
// DeviceVendorEnum that is the union of the values from
// all the schema versions.
#if MERGE_VENDOR_ENUMS
            SchemaVersionMap.MergeVendorEnums( );
#endif

            foreach( var pdsc in Directory.EnumerateFiles( RepoProvider.Repository.WebRoot, "*.pdsc" ) )
            {
                ActivePackDescription = pdsc;
                var doc = XDocument.Load( pdsc );
                ActiveSchemaVersion = ( from package in doc.Elements( "package" )
                                        let version = package.Attribute( "schemaVersion" )
                                        where version != null
                                        select version.Value
                                      ).FirstOrDefault( );

                SchemaMapEntry mapEntry;
                if( !SchemaVersionMap.TryGetValue( ActiveSchemaVersion, out mapEntry ) )
                {
                    Console.Error.WriteLine( $"ERROR: {pdsc}: Unknown schemaVersion='{ActiveSchemaVersion}'" );
                }
                else
                {
                    var schemaSet = new XmlSchemaSet( );
                    schemaSet.Add( mapEntry.Schema );
                    doc.Validate( schemaSet, ValidationHandler );
                }
            }
            if( System.Diagnostics.Debugger.IsAttached )
                Console.ReadLine( );
        }
        static string ActiveSchemaVersion;
        static string ActivePackDescription;

        private static void ValidationHandler( object sender, ValidationEventArgs e )
        {
            // Unfortunately "({e.Exception.LineNumber},{e.Exception.LinePosition})" always ends up as (0,0)
            Console.Error.WriteLine( $"ERROR: using Schema version {ActiveSchemaVersion} with {ActivePackDescription}: {e.Message}" );
        }
    }
}
