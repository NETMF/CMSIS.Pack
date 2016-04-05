using System;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    [XmlType( AnonymousType=true)]
    public class GeneratorTypeExtensions {
    
        private System.Xml.XmlElement[] anyField;
    
        /// <remarks/>
        [XmlAnyElement( )]
        public System.Xml.XmlElement[] Any {
            get {
                return anyField;
            }
            set {
                anyField = value;
            }
        }
    }
}