using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public class Condition
    {
        /// <remarks/>
        [XmlElement( "description")]
        public string Description { get; set; }
    
        /// <remarks/>
        //REVIEW: Should these be grouped under a common base, using the ItemsElementName to determine the "type" is awkward
        [XmlElement( "accept", typeof(FilterType))]
        [XmlElement( "deny", typeof(FilterType))]
        [XmlElement( "require", typeof(FilterType))]
        [XmlChoiceIdentifier( "ItemsElementName")]
        public FilterType[] Items { get; set; }
    
        /// <remarks/>
        [XmlElement( "ItemsElementName")]
        [XmlIgnore( )]
        public ItemsChoiceType[] ItemsElementName { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "id", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Id { get; set; }
    }
}