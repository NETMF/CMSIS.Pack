using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class GeneratorType {
    
        private string descriptionField;
    
        private GeneratorDeviceSelectType selectField;
    
        private string commandField;
    
        private string workingDirField;
    
        private GeneratorCommandArgumentType[] argumentsField;
    
        private GpdscFileType gpdscField;
    
        private FileType[] project_filesField;
    
        private GeneratorFileType[] filesField;
    
        private GeneratorTypeExtensions extensionsField;
    
        private string idField;
    
        private string gvendorField;
    
        private string gtoolField;
    
        private string gversionField;
    
        /// <remarks/>
        public string description {
            get {
                return descriptionField;
            }
            set {
                descriptionField = value;
            }
        }
    
        /// <remarks/>
        public GeneratorDeviceSelectType select {
            get {
                return selectField;
            }
            set {
                selectField = value;
            }
        }
    
        /// <remarks/>
        public string command {
            get {
                return commandField;
            }
            set {
                commandField = value;
            }
        }
    
        /// <remarks/>
        public string workingDir {
            get {
                return workingDirField;
            }
            set {
                workingDirField = value;
            }
        }
    
        /// <remarks/>
        [XmlArrayItem( "argument", IsNullable=false)]
        public GeneratorCommandArgumentType[] arguments {
            get {
                return argumentsField;
            }
            set {
                argumentsField = value;
            }
        }
    
        /// <remarks/>
        public GpdscFileType gpdsc {
            get {
                return gpdscField;
            }
            set {
                gpdscField = value;
            }
        }
    
        /// <remarks/>
        [XmlArrayItem( "file", IsNullable=false)]
        public FileType[] project_files {
            get {
                return project_filesField;
            }
            set {
                project_filesField = value;
            }
        }
    
        /// <remarks/>
        [XmlArrayItem( "file", IsNullable=false)]
        public GeneratorFileType[] files {
            get {
                return filesField;
            }
            set {
                filesField = value;
            }
        }
    
        /// <remarks/>
        public GeneratorTypeExtensions extensions {
            get {
                return extensionsField;
            }
            set {
                extensionsField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string id {
            get {
                return idField;
            }
            set {
                idField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Gvendor {
            get {
                return gvendorField;
            }
            set {
                gvendorField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Gtool {
            get {
                return gtoolField;
            }
            set {
                gtoolField = value;
            }
        }
    
        /// <remarks/>
        [XmlAttribute( Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Gversion {
            get {
                return gversionField;
            }
            set {
                gversionField = value;
            }
        }
    }
}