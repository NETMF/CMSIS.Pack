using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    [XmlType( AnonymousType=true )]
    [XmlRoot( Namespace="", ElementName ="package", IsNullable=true)]
    public partial class Package
    {
        [XmlElement("name")]
        public string Name { get; set; }

        /// <remarks/>
        [XmlElement( "vendor" )]
        public string Vendor { get; set; }

        /// <remarks/>
        [XmlElement( "description" )]
        public string Description { get; set; }

        /// <remarks/>
        [XmlElement( "url", DataType ="anyURI")]
        public string Url { get; set; }

        /// <remarks/>
        [XmlElement( "supportContact" )]
        public string SupportContact { get; set; }

        /// <remarks/>
        [XmlElement( "license" )]
        public string License { get; set; }

        /// <remarks/>
        [XmlArrayItem( "release", IsNullable=false)]
        [XmlArray( "releases" )]
        public Release[] Releases { get; set; }

        /// <remarks/>
        [XmlArrayItem( "keyword", IsNullable=false)]
        [XmlArray( "keywords" )]
        public string[] Keywords { get; set; }

        /// <remarks/>
        [XmlArrayItem( "generator", IsNullable=false)]
        [XmlArray( "generators" )]
        public GeneratorType[] Generators { get; set; }

        /// <remarks/>
        [XmlArrayItem( "family", IsNullable=false)]
        [XmlArray( "devices" )]
        public Family[] Devices { get; set; }

        /// <remarks/>
        [XmlArrayItem( "board", IsNullable=false)]
        [XmlArray( "boards" )]
        public Board[] Boards { get; set; }

        /// <remarks/>
        [XmlArrayItem( "description", IsNullable=false)]
        [XmlArray( "taxonomy" )]
        public TaxonomyDescriptionType[] Taxonomy { get; set; }

        /// <remarks/>
        [XmlArrayItem( "api", IsNullable=false)]
        [XmlArray( "apis" )]
        public ApiType[] Apis { get; set; }

        /// <remarks/>
        [XmlArrayItem( "condition", IsNullable=false)]
        [XmlArray( "conditions" )]
        public ConditionType[] Conditions { get; set; }

        /// <remarks/>
        [XmlArrayItem( "example", IsNullable=false)]
        [XmlArray( "examples" )]
        public ExampleType[] Examples { get; set; }

        /// <remarks/>
        [XmlArrayItem( "bundle", typeof( Bundle ) )]
        [XmlArrayItem( "component", typeof( Component ) )]
        [XmlArray( "components", IsNullable = false )]
        public ComponenOrBundleGroup[] Components { get; set; }

        /// <remarks/>
        [XmlAttribute( "schemaVersion", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string SchemaVersion { get; set; }

        public static async Task<Package> ParseFromPathAsync( string path )
        {
            using( var rdr = File.OpenText( path ) )
            {
                return await ParseAsync( rdr );
            }
        }

        public static async Task<Package> ParseAsync( string xmlContent )
        {
            using( var rdr = new StringReader( xmlContent ) )
            {
                return await ParseAsync( rdr );
            }
        }

        public static async Task<Package> ParseAsync( TextReader textReader )
        {
            var ser = new XmlSerializer( typeof( Package ) );
            // force ignoring of comments as they are commonly placed in
            // locations that the serializer can't handle
            using( var rdr = XmlReader.Create( textReader, new XmlReaderSettings( ) { IgnoreComments = true } ) )
            {
                return await Task.Run( ( ) =>
                {
                    var pkg = ( Package )ser.Deserialize( rdr );
                    return pkg;
                } );
            }
        }
    }
}