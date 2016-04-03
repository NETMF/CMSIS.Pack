using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class DebugInterfaceType {
    
        private string adapterField;
    
        private string connectorField;
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string adapter {
            get {
                return adapterField;
            }
            set {
                adapterField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string connector {
            get {
                return connectorField;
            }
            set {
                connectorField = value;
            }
        }
    }
}