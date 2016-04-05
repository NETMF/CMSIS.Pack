using System;
using System.Xml;
using System.Xml.Serialization;
using SemVer.NET;

namespace CMSIS.Pack.PackDescription
{
    /// <summary>Describes the /package/examples/example/attributes/component element</summary>
    [Serializable( )]
    public class ComponentCategory
    {
        /// <remarks/>
        [XmlAttribute( "Cvendor", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Vendor { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "Cbundle", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Cbundle { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "Cclass", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Class { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "Cgroup", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Group { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "Csub", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string SubGroup { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "Cvariant", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Variant { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "Cversion", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string RawCversionString
        {
            get { return Version.ToString(); }
            set { Version = SemanticVersion.Parse( value ); }
        }

        [XmlIgnore]
        public SemanticVersion Version { get; set; }

        /// <remarks/>
        [XmlAttribute( "CapiVersion", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [System.ComponentModel.EditorBrowsable( System.ComponentModel.EditorBrowsableState.Never )]
        public string RawCapiversionString
        {
            get { return ApiVersion.ToString(); }
            set { ApiVersion = SemanticVersion.Parse( value ); }
        }

        [XmlIgnore]
        public SemanticVersion ApiVersion { get; set; }
    }
}