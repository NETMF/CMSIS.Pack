using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class BoardsDeviceType {
    
        private string deviceIndexField;
    
        private DeviceVendorEnum dvendorField;
    
        private string dfamilyField;
    
        private string dsubFamilyField;
    
        private string dnameField;
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string deviceIndex {
            get {
                return deviceIndexField;
            }
            set {
                deviceIndexField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public DeviceVendorEnum Dvendor {
            get {
                return dvendorField;
            }
            set {
                dvendorField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Dfamily {
            get {
                return dfamilyField;
            }
            set {
                dfamilyField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string DsubFamily {
            get {
                return dsubFamilyField;
            }
            set {
                dsubFamilyField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Dname {
            get {
                return dnameField;
            }
            set {
                dnameField = value;
            }
        }
    }
}