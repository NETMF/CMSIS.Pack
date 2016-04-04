using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    /// <remarks/>
    [Serializable( )]
    public partial class BoardReference
    {
        /// <remarks/>
        [XmlAttribute( "name", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Name { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "vendor", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string BoardVendor { get; set; }

        /// <remarks/>
        [XmlAttribute( "DVendor", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [System.ComponentModel.EditorBrowsable( System.ComponentModel.EditorBrowsableState.Never )]
        public string RawDeviceVendorString
        {
            get { return DeviceVendor.ToString(); }
            set { DeviceVendor = DeviceVendor.Parse( value ); }
        }

        [XmlIgnore]
        DeviceVendor DeviceVendor { get; set; }

        /// <remarks/>
        [XmlAttribute( "Dfamily", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string DeviceFamily { get; set;}
    
        /// <remarks/>
        [XmlAttribute( "DsubFamily", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string DeviceSubFamily { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "Dname", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string DeviceName { get; set; }
    }
}