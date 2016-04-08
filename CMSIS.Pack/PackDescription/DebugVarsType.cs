using System;
using System.Xml;
using System.Xml.Serialization;
using SemVer.NET;
using Sprache;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public class DebugVarsType
    {
        /// <remarks/>
        [XmlAttribute( "configfile", Form=System.Xml.Schema.XmlSchemaForm.Qualified )]
        public string ConfigFile { get; set; }

        [XmlAttribute( "version", Form = System.Xml.Schema.XmlSchemaForm.Qualified )]
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

        /// <remarks/>
        [XmlAttribute( "Pname", Form = System.Xml.Schema.XmlSchemaForm.Qualified )]
        public string ProcessorName
        {
            get { return ProcessorName_; }
            set { ProcessorName_ = Parsers.RestrictedString.Parse( value ); }
        }
        private string ProcessorName_;

        /// <remarks/>
        [XmlAnyAttribute( )]
        public XmlAttribute[ ] AnyAttr { get; set; }
    
        /// <remarks/>
        [XmlText( )]
        public string Value { get; set; }
    }
}