using System;
using System.Xml;
using System.Xml.Serialization;
using Sprache;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class ProcessorType {
    
        private DcoreEnum dcoreField;
    
        private bool dcoreFieldSpecified;
    
        private DfpuEnum dfpuField;
    
        private bool dfpuFieldSpecified;
    
        private DmpuEnum dmpuField;
    
        private bool dmpuFieldSpecified;
    
        private DendianEnum dendianField;
    
        private bool dendianFieldSpecified;
    
        private uint dclockField;
    
        private bool dclockFieldSpecified;
    
        private string dcoreVersionField;

        /// <remarks/>
        [XmlAttribute( "Pname", Form = System.Xml.Schema.XmlSchemaForm.Qualified )]
        public string ProcessorName
        {
            get { return ProcessorName_; }
            set { ProcessorName_ = Parsers.RestrictedString.Parse( value ); }
        }
        private string ProcessorName_;

        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public DcoreEnum Dcore {
            get {
                return dcoreField;
            }
            set {
                dcoreField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool DcoreSpecified {
            get {
                return dcoreFieldSpecified;
            }
            set {
                dcoreFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public DfpuEnum Dfpu {
            get {
                return dfpuField;
            }
            set {
                dfpuField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool DfpuSpecified {
            get {
                return dfpuFieldSpecified;
            }
            set {
                dfpuFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public DmpuEnum Dmpu {
            get {
                return dmpuField;
            }
            set {
                dmpuField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool DmpuSpecified {
            get {
                return dmpuFieldSpecified;
            }
            set {
                dmpuFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public DendianEnum Dendian {
            get {
                return dendianField;
            }
            set {
                dendianField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool DendianSpecified {
            get {
                return dendianFieldSpecified;
            }
            set {
                dendianFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public uint Dclock {
            get {
                return dclockField;
            }
            set {
                dclockField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool DclockSpecified {
            get {
                return dclockFieldSpecified;
            }
            set {
                dclockFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string DcoreVersion {
            get {
                return dcoreVersionField;
            }
            set {
                dcoreVersionField = value;
            }
        }
    }
}