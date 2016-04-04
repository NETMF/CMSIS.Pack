using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class ApiType
    {
        public ApiType()
        {
            Exclusive = true;
        }

        /// <remarks/>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <remarks/>
        [XmlArray("files")]
        [XmlArrayItem( "file", IsNullable=false)]
        public FileType[] Files { get; set; }

        /// <remarks/>
        [XmlAttribute( "Cclass", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Class { get; set; }

        /// <remarks/>
        [XmlAttribute( "Cgroup", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Group { get; set; }

        /// <remarks/>
        [XmlAttribute( "exclusive", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [DefaultValue( true )]
        public bool Exclusive { get; set; }

        /// <remarks/>
        [XmlAttribute( "CapiVersion", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string ApiVersionString
        {
            get { return ApiVersion.ToString(); }
            set
            {
                ApiVersion = SemanticVersion.Parse( value, SemanticVersionParseOptions.PatchOptional );
            }
        }

        [XmlIgnore]
        public SemanticVersion ApiVersion { get; set; }
    }
}