using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml;
using System.IO;

namespace ValidatePackSchema
{
    internal class SchemaMapEntry
    {
        public SchemaMapEntry( string version, string resourceName )
        {
            Version = version;
            PackResourceName = resourceName;
            LazySchemaDoc = new Lazy<XDocument>( LoadSchemaDoc );
            LazySchema = new Lazy<XmlSchema>( LoadSchema );
        }

        public string Version { get; }
        public string PackResourceName { get; }
        public XDocument SchemaDoc => LazySchemaDoc.Value;
        public XmlSchema Schema => LazySchema.Value;

        private XDocument LoadSchemaDoc( )
        {
            using( var strm = Assembly.GetExecutingAssembly( ).GetManifestResourceStream( PackResourceName ) )
            {
                return XDocument.Load( strm );
            }
        }

        private XmlSchema LoadSchema( )
        {
            using( var rdr = new StringReader( SchemaDoc.ToString( ) ) )
            {
                return XmlSchema.Read( rdr, ValidationHandler );
            }
        }

        private static void ValidationHandler( object sender, ValidationEventArgs e )
        {
            // Unfortunately "({e.Exception.LineNumber},{e.Exception.LinePosition})" always ends up as (0,0)
            Console.Error.WriteLine( $"ERROR: {e.Exception.SourceUri}: {e.Message}" );
        }

        private Lazy<XDocument> LazySchemaDoc;
        private Lazy<XmlSchema> LazySchema;
    }

    class SchemaMap
        : KeyedCollection<string, SchemaMapEntry>
    {
        protected override string GetKeyForItem( SchemaMapEntry item ) => item.Version;

        public bool TryGetValue( string ver, out SchemaMapEntry entry )
        {
            entry = null;
            if( Dictionary == null )
                return false;

            return Dictionary.TryGetValue( ver, out entry );
        }

        /// <summary>Works around errant PSDC files by merging all DeviceVendorEnum sets</summary>
        /// <remarks>
        /// Many PDSC files in the real world contain DeviceVendorEnum values not listed in the 
        /// schema version the PSDC claims to be from. This, will try and deal with the issue
        /// by merging all known values from all of the available schemas. Then, replacing all
        /// of the schemas nodes with a newly created one containing the full list.
        /// </remarks>
        public void MergeVendorEnums()
        {
            // find all the xs:restrictions whose child xs:enumerations elements should be replaced
            var restrictions = from entry in Dictionary.Values
                               from simpleType in entry.SchemaDoc.Descendants( XsSimpleType )
                               let nameAttrib = simpleType.Attribute("name")
                               where nameAttrib != null && nameAttrib.Value == "DeviceVendorEnum"
                               from restriction in simpleType.Descendants( XsRestriction )
                               select restriction;

            // construct a new set of enumeration elements that is the union of 
            // all the of enumerations from all the schemas
            var newEnums = ( from restriction in restrictions
                             from enumeration in restriction.Descendants( XsEnumeration )
                             select enumeration.Attribute( "value" ).Value
                           ).Distinct( )
                            .Select( value => new XElement( XsEnumeration, new XAttribute( "value", value ) ) )
                            .ToArray();

            // replace the enumeration sets in each schema
            foreach( var restriction in restrictions )
            {
                restriction.ReplaceNodes( newEnums );
            }
        }

        const string XSDNamespace = "http://www.w3.org/2001/XMLSchema";

        XName XsSimpleType = XName.Get( "simpleType", XSDNamespace );
        XName XsRestriction = XName.Get( "restriction", XSDNamespace );
        XName XsEnumeration = XName.Get( "enumeration", XSDNamespace );
    }
}
