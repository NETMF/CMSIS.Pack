using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using SemVer.NET;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    [XmlType( AnonymousType=true)]
    public class Component 
        : ComponenOrBundleGroup
    {
        [DefaultValue( false )]
        [XmlElement("deprecated")]
        public bool IsDeprecated { get; set; }

        /// <remarks/>
        public string RTE_Components_h { get; set; }
    
        /// <remarks/>
        [XmlArray("files")]
        [XmlArrayItem( "file", IsNullable=false)]
        public FileType[] Files { get; set; }

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
        [XmlAttribute( "Capiversion", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [System.ComponentModel.EditorBrowsable( System.ComponentModel.EditorBrowsableState.Never )]
        public string RawApiVersionString
        {
            get { return Version.ToString( ); }
            set
            {
                // NOTE: Gracefully handle some real-world PDSC files with simple versions
                Version = SemanticVersion.Parse( value, ParseOptions.PatchOptional );
            }
        }

        [XmlIgnore]
        public SemanticVersion ApiVersion { get; set; }

        /// <remarks/>
        [XmlAttribute( "condition", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Condition { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "maxInstances", Form=System.Xml.Schema.XmlSchemaForm.Qualified )]
        public int MaxInstances { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "generator", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Generator { get; set; }
    }
}