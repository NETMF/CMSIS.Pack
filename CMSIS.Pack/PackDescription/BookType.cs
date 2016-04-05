using System;
using System.Xml;
using System.Xml.Serialization;
using Sprache;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public class BookType
    {
        /// <remarks/>
        [XmlAttribute( "Pname", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string ProcessorName {
            get { return ProcessorName_; }
            set { ProcessorName_ = Parsers.RestrictedString.Parse( value ); }
        }
        private string ProcessorName_;

        /// <remarks/>
        [XmlAttribute( "name", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Name { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "title", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Title { get; set; }
    }
}