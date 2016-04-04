using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class Board
    {
        /// <remarks/>
        [XmlElement( "description")]
        public string[] Description { get; set; }
    
        /// <remarks/>
        [XmlElement( "feature")]
        public BoardFeature[] Feature { get; set; }

        /// <remarks/>
        [XmlElement( "mountedDevice")]
        public BoardsDevice[] MountedDevice { get; set; }

        /// <remarks/>
        [XmlElement( "compatibleDevice")]
        public CompatibleDeviceType[] CompatibleDevice { get; set; }

        /// <remarks/>
        [XmlElement( "image")]
        public BoardImage[] Image { get; set; }

        /// <remarks/>
        [XmlElement( "debugInterface")]
        public DebugInterfaceType[] DebugInterface { get; set; }

        /// <remarks/>
        [XmlElement( "book")]
        public BoardBook[] Book { get; set; }

        /// <remarks/>
        [XmlAttribute( "vendor", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Vendor { get; set; }

        /// <remarks/>
        [XmlAttribute( "name", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Name { get; set; }

        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Revision { get; set; }

        /// <remarks/>
        [XmlAttribute( "salesContact", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string SalesContact { get; set; }

        /// <remarks/>
        [XmlAttribute( "orderForm", Form=System.Xml.Schema.XmlSchemaForm.Qualified, DataType="anyURI")]
        public string OrderForm { get; set; }
    }
}