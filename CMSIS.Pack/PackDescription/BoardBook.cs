using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class BoardBook
    {
        /// <remarks/>
        [XmlAttribute( "category", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public BoardBookCategoryEnum Category { get; set; }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool CategorySpecified { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "name", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Name { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "title", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Title { get; set; }
    }
}