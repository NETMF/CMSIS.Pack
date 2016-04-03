using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    /// <remarks/>
    [Serializable( )]
    public partial class ExampleAttributesType
    {
    
        private object[] itemsField;
    
        private ItemsChoiceType1[] itemsElementNameField;
    
        /// <remarks/>
        [XmlElement( "category", typeof(string))]
        [XmlElement( "component", typeof(ComponentCategoryType))]
        [XmlElement( "keyword", typeof(string))]
        [XmlChoiceIdentifier( "ItemsElementName")]
        public object[] Items {
            get {
                return itemsField;
            }
            set {
                itemsField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "ItemsElementName")]
        [XmlIgnore( )]
        public ItemsChoiceType1[] ItemsElementName {
            get {
                return itemsElementNameField;
            }
            set {
                itemsElementNameField = value;
            }
        }
    }
}