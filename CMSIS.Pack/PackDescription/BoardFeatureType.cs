using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class BoardFeatureType {
    
        private string typeField;
    
        private decimal nField;
    
        private bool nFieldSpecified;
    
        private decimal mField;
    
        private bool mFieldSpecified;
    
        private string nameField;
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string type {
            get {
                return typeField;
            }
            set {
                typeField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public decimal n {
            get {
                return nField;
            }
            set {
                nField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool nSpecified {
            get {
                return nFieldSpecified;
            }
            set {
                nFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public decimal m {
            get {
                return mField;
            }
            set {
                mField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool mSpecified {
            get {
                return mFieldSpecified;
            }
            set {
                mFieldSpecified = value;
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
    }
}