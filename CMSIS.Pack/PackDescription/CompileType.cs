using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class CompileType {
    
        private string pnameField;
    
        private string headerField;
    
        private string defineField;
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Pname {
            get {
                return pnameField;
            }
            set {
                pnameField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string header {
            get {
                return headerField;
            }
            set {
                headerField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string define {
            get {
                return defineField;
            }
            set {
                defineField = value;
            }
        }
    }
}