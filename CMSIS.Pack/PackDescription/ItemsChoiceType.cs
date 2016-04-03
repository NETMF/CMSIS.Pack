using System;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    [XmlType( IncludeInSchema=false)]
    public enum ItemsChoiceType {
    
        /// <remarks/>
        accept,
    
        /// <remarks/>
        deny,
    
        /// <remarks/>
        require,
    }
}