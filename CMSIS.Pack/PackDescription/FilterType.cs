using System;
using System.Xml;
using System.Xml.Serialization;
using Sprache;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public class FilterType {
    
        private string dfamilyField;
    
        private string dsubFamilyField;
    
        private string dvariantField;
    
        private DeviceVendorEnum dvendorField;
    
        private bool dvendorFieldSpecified;
    
        private string dnameField;
    
        private DcoreEnum dcoreField;
    
        private bool dcoreFieldSpecified;
    
        private DfpuEnum dfpuField;
    
        private bool dfpuFieldSpecified;
    
        private DmpuEnum dmpuField;
    
        private bool dmpuFieldSpecified;
    
        private DendianEnum dendianField;
    
        private bool dendianFieldSpecified;
    
        private string cvendorField;
    
        private string cbundleField;
    
        private string cclassField;
    
        private string cgroupField;
    
        private string csubField;
    
        private string cvariantField;
    
        private string cversionField;
    
        private string capiversionField;
    
        private CompilerEnumType tcompilerField;
    
        private bool tcompilerFieldSpecified;
    
        private CompilerOutputType toutputField;
    
        private bool toutputFieldSpecified;
    
        private string conditionField;
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Dfamily {
            get {
                return dfamilyField;
            }
            set {
                dfamilyField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string DsubFamily {
            get {
                return dsubFamilyField;
            }
            set {
                dsubFamilyField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Dvariant {
            get {
                return dvariantField;
            }
            set {
                dvariantField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public DeviceVendorEnum Dvendor {
            get {
                return dvendorField;
            }
            set {
                dvendorField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool DvendorSpecified {
            get {
                return dvendorFieldSpecified;
            }
            set {
                dvendorFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Dname {
            get {
                return dnameField;
            }
            set {
                dnameField = value;
            }
        }
    
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
        [XmlAttribute( "Pname", Form = System.Xml.Schema.XmlSchemaForm.Qualified )]
        public string ProcessorName
        {
            get { return ProcessorName_; }
            set { ProcessorName_ = Parsers.RestrictedString.Parse( value ); }
        }
        private string ProcessorName_;

        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Cvendor {
            get {
                return cvendorField;
            }
            set {
                cvendorField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Cbundle {
            get {
                return cbundleField;
            }
            set {
                cbundleField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Cclass {
            get {
                return cclassField;
            }
            set {
                cclassField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Cgroup {
            get {
                return cgroupField;
            }
            set {
                cgroupField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Csub {
            get {
                return csubField;
            }
            set {
                csubField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Cvariant {
            get {
                return cvariantField;
            }
            set {
                cvariantField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Cversion {
            get {
                return cversionField;
            }
            set {
                cversionField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Capiversion {
            get {
                return capiversionField;
            }
            set {
                capiversionField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public CompilerEnumType Tcompiler {
            get {
                return tcompilerField;
            }
            set {
                tcompilerField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool TcompilerSpecified {
            get {
                return tcompilerFieldSpecified;
            }
            set {
                tcompilerFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public CompilerOutputType Toutput {
            get {
                return toutputField;
            }
            set {
                toutputField = value;
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public bool ToutputSpecified {
            get {
                return toutputFieldSpecified;
            }
            set {
                toutputFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string condition {
            get {
                return conditionField;
            }
            set {
                conditionField = value;
            }
        }
    }
}