using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public class GeneratorCommandArgumentType {
    
        private string switchField;
    
        private string valueField;
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string @switch {
            get {
                return switchField;
            }
            set {
                switchField = value;
            }
        }
    
        /// <remarks/>
        [XmlText( )]
        public string Value {
            get {
                return valueField;
            }
            set {
                valueField = value;
            }
        }
    }
}