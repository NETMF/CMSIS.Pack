using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class ConditionType {
    
        private string descriptionField;
    
        private FilterType[] itemsField;
    
        private ItemsChoiceType[] itemsElementNameField;
    
        private string idField;
    
        /// <remarks/>
        public string description {
            get {
                return descriptionField;
            }
            set {
                descriptionField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "accept", typeof(FilterType))]
        [XmlElement( "deny", typeof(FilterType))]
        [XmlElement( "require", typeof(FilterType))]
        [XmlChoiceIdentifier( "ItemsElementName")]
        public FilterType[] Items {
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
        public ItemsChoiceType[] ItemsElementName {
            get {
                return itemsElementNameField;
            }
            set {
                itemsElementNameField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string id {
            get {
                return idField;
            }
            set {
                idField = value;
            }
        }
    }
}