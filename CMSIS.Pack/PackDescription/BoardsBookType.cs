using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class BoardsBookType {
    
        private BoardBookCategoryEnum categoryField;
    
        private bool categoryFieldSpecified;
    
        private string nameField;
    
        private string titleField;
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public BoardBookCategoryEnum category {
            get {
                return categoryField;
            }
            set {
                categoryField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool categorySpecified {
            get {
                return categoryFieldSpecified;
            }
            set {
                categoryFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string name {
            get {
                return nameField;
            }
            set {
                nameField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string title {
            get {
                return titleField;
            }
            set {
                titleField = value;
            }
        }
    }
}