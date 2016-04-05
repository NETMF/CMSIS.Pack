using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public class DebugDataPatch
    {
        /// <remarks/>
        [XmlAttribute( "type", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public DataPatchAccessTypeEnum PatchType { get; set; }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool PatchTypeSpecified { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "address", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Address { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "__dp", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public uint DebugPortId { get; set; }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool DebugPortIdSpecified { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "__ap", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public uint AccessPortIndex { get; set; }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool AccessPortIndexSpecified { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "value", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Value { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "mask", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Mask { get; set; }
    
        /// <remarks/>
        [XmlAttribute( "info", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Info { get; set; }
    
        /// <remarks/>
        [XmlAnyAttribute( )]
        public XmlAttribute[ ] AnyAttr {get; set; }
    }
}