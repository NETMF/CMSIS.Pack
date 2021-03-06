using System.Xml;
using System.Xml.Serialization;
using SemVer.NET;

namespace CMSIS.Pack.PackDescription
{
    public class ComponenOrBundleGroup
    {
        [XmlAttribute("Cvendor")]
        public string Vendor { get; set; }

        [XmlAttribute("Cclass")]
        public string Class { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlAttribute( "Cversion", Form = System.Xml.Schema.XmlSchemaForm.Qualified )]
        [System.ComponentModel.EditorBrowsable( System.ComponentModel.EditorBrowsableState.Never )]
        public string RawVersionString
        {
            get { return Version.ToString( ); }
            set
            {
                Version = VersionParser.Parse( value );
            }
        }

        [XmlIgnore]
        public SemanticVersion Version { get; set; }
    }
}