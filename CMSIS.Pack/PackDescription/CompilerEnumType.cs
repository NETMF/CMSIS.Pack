using System;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public enum CompilerEnumType {
    
        /// <remarks/>
        GCC,
    
        /// <remarks/>
        ARMCC,
    
        /// <remarks/>
        IAR,
    
        /// <remarks/>
        Tasking,
    
        /// <remarks/>
        GHS,
    
        /// <remarks/>
        Cosmic,
    
        /// <remarks/>
        [XmlEnum( "G++")]
        G,
    
        /// <remarks/>
        [XmlEnum( "*")]
        Item,
    }
}