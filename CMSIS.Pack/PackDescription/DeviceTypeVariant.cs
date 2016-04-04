using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    [XmlType( AnonymousType=true)]
    public partial class DeviceTypeVariant {
    
        private ProcessorType[] processorField;
    
        private DebugConfigType debugconfigField;
    
        private CompileType[] compileField;
    
        private MemoryType[] memoryField;
    
        private Algorithm[] algorithmField;
    
        private BookType[] bookField;
    
        private DescriptionType[] descriptionField;
    
        private DeviceFeatureType[] featureField;
    
        private EnvironmentType[] environmentField;
    
        private DebugPortType[] debugportField;
    
        private DebugType[] debugField;
    
        private TraceType[] traceField;
    
        private DebugVarsType[] debugvarsField;
    
        private SequencesType[] sequencesField;
    
        private string dvariantField;
    
        /// <remarks/>
        [XmlElement( "processor")]
        public ProcessorType[] processor {
            get {
                return processorField;
            }
            set {
                processorField = value;
            }
        }
    
        /// <remarks/>
        public DebugConfigType debugconfig {
            get {
                return debugconfigField;
            }
            set {
                debugconfigField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "compile")]
        public CompileType[] compile {
            get {
                return compileField;
            }
            set {
                compileField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "memory")]
        public MemoryType[] memory {
            get {
                return memoryField;
            }
            set {
                memoryField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "algorithm")]
        public Algorithm[] algorithm {
            get {
                return algorithmField;
            }
            set {
                algorithmField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "book")]
        public BookType[] book {
            get {
                return bookField;
            }
            set {
                bookField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "description")]
        public DescriptionType[] description {
            get {
                return descriptionField;
            }
            set {
                descriptionField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "feature")]
        public DeviceFeatureType[] feature {
            get {
                return featureField;
            }
            set {
                featureField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "environment")]
        public EnvironmentType[] environment {
            get {
                return environmentField;
            }
            set {
                environmentField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "debugport")]
        public DebugPortType[] debugport {
            get {
                return debugportField;
            }
            set {
                debugportField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "debug")]
        public DebugType[] debug {
            get {
                return debugField;
            }
            set {
                debugField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "trace")]
        public TraceType[] trace {
            get {
                return traceField;
            }
            set {
                traceField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "debugvars")]
        public DebugVarsType[] debugvars {
            get {
                return debugvarsField;
            }
            set {
                debugvarsField = value;
            }
        }
    
        /// <remarks/>
        [XmlElement( "sequences")]
        public SequencesType[] sequences {
            get {
                return sequencesField;
            }
            set {
                sequencesField = value;
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
    }
}