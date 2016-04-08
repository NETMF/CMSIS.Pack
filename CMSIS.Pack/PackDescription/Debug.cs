using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using Sprache;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public class Debug
    {
        /// <remarks/>
        [XmlElement( "datapatch")]
        public DebugDataPatch[] Datapatch { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "__dp", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [DefaultValue( 0 )]
        public uint DebugPortId { get; set; } = 0;
    
        /// <remarks/>
        [XmlAttribute( "__ap", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [DefaultValue( 0 )]
        public uint AccessPortIndex { get; set; } = 0;
    
        /// <remarks/>
        [XmlAttribute( "svd", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string SvdFile { get; set; }

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
    }
}