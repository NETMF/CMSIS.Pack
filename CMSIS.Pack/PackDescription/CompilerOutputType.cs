using System;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public enum CompilerOutputType {
    
        /// <remarks/>
        exe,
    
        /// <remarks/>
        lib,
    
        /// <remarks/>
        [XmlEnum( "*")]
        Item,
    }
}