using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    [XmlType( AnonymousType=true)]
    public class BoardImage
    {
        /// <remarks/>
        [XmlAttribute( "small", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Small { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "large", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string large { get; set; }
    }
}