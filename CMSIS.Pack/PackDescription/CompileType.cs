using System;
using System.Xml;
using System.Xml.Serialization;
using Sprache;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public class CompileType
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
        [XmlAttribute( "header", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Header { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "define", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Define { get; set; }
    }
}