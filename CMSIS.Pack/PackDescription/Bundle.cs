using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    [XmlType( AnonymousType = true )]
    public partial class Bundle : ComponenOrBundleGroup
    {
        private string docField;

        private Component[] componentField;

        private string cbundleField;

        private string generatorField;

        /// <remarks/>
        public string doc
        {
            get
            {
                return docField;
            }
            set
            {
                docField = value;
            }
        }

        /// <remarks/>
        [XmlElement( "component" )]
        public Component[ ] component
        {
            get
            {
                return componentField;
            }
            set
            {
                componentField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute( Form = System.Xml.Schema.XmlSchemaForm.Qualified )]
        public string Cbundle
        {
            get
            {
                return cbundleField;
            }
            set
            {
                cbundleField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute( Form = System.Xml.Schema.XmlSchemaForm.Qualified )]
        public string generator
        {
            get
            {
                return generatorField;
            }
            set
            {
                generatorField = value;
            }
        }
    }
}