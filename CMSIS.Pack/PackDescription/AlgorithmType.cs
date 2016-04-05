using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using Sprache;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public class Algorithm
    {
        /// <remarks/>
        [XmlAttribute( "Pname", Form = System.Xml.Schema.XmlSchemaForm.Qualified )]
        public string ProcessorName
        {
            get { return ProcessorName_; }
            set { ProcessorName_ = Parsers.RestrictedString.Parse( value ); }
        }
        private string ProcessorName_;

        /// <remarks/>
        [XmlAttribute( "name", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Name { get; set; }

        /// <remarks/>
        [XmlAttribute( "start", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Start { get; set; }

        /// <remarks/>
        [XmlAttribute( "size", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Size { get; set; }

        /// <remarks/>
        [XmlAttribute( "RAMstart", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string RAMStart { get; set; }

        /// <remarks/>
        [XmlAttribute( "RAMsize", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string RAMSize { get; set; }

        /// <remarks/>
        [XmlAttribute( "default", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [DefaultValue( false )]
        public bool Default { get; set; }
    }
}