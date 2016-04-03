using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class BoardType {
    
        private string[] descriptionField;
    
        private BoardFeatureType[] featureField;
    
        private BoardsDeviceType[] mountedDeviceField;
    
        private CompatibleDeviceType[] compatibleDeviceField;
    
        private BoardTypeImage[] imageField;
    
        private DebugInterfaceType[] debugInterfaceField;
    
        private BoardsBookType[] bookField;
    
        private string vendorField;
    
        private string nameField;
    
        private string revisionField;
    
        private string salesContactField;
    
        private string orderFormField;
    
        /// <remarks/>
        [XmlElement( "description")]
        public string[] description {
            get {
                return descriptionField;
            }
            set {
                descriptionField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "feature")]
        public BoardFeatureType[] feature {
            get {
                return featureField;
            }
            set {
                featureField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "mountedDevice")]
        public BoardsDeviceType[] mountedDevice {
            get {
                return mountedDeviceField;
            }
            set {
                mountedDeviceField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "compatibleDevice")]
        public CompatibleDeviceType[] compatibleDevice {
            get {
                return compatibleDeviceField;
            }
            set {
                compatibleDeviceField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "image")]
        public BoardTypeImage[] image {
            get {
                return imageField;
            }
            set {
                imageField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "debugInterface")]
        public DebugInterfaceType[] debugInterface {
            get {
                return debugInterfaceField;
            }
            set {
                debugInterfaceField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "book")]
        public BoardsBookType[] book {
            get {
                return bookField;
            }
            set {
                bookField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string vendor {
            get {
                return vendorField;
            }
            set {
                vendorField = value;
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
        public string revision {
            get {
                return revisionField;
            }
            set {
                revisionField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string salesContact {
            get {
                return salesContactField;
            }
            set {
                salesContactField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified, DataType="anyURI")]
        public string orderForm {
            get {
                return orderFormField;
            }
            set {
                orderFormField = value;
            }
        }
    }
}