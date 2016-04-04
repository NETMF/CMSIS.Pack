using System;
using System.Xml;
using System.Xml.Serialization;
using Sprache;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class GeneratorDeviceSelectType {
    
        private DeviceVendorEnum dvendorField;
    
        private string dnameField;
    
        private string dvariantField;
    
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
        public string Dname {
            get {
                return dnameField;
            }
            set {
                dnameField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Dvariant {
            get {
                return dvariantField;
            }
            set {
                dvariantField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute( "Pname", Form = System.Xml.Schema.XmlSchemaForm.Qualified )]
        public string ProcessorName
        {
            get { return ProcessorName_; }
            set { ProcessorName_ = Parsers.RestrictedString.Parse( value ); }
        }
        private string ProcessorName_;
    }
}