using System;
using System.Xml;
using System.Xml.Serialization;
using Sprache;

namespace CMSIS.Pack.PackDescription
{
    [Serializable( )]
    public partial class BoardFeature
    {
        /// <remarks/>
        [XmlAttribute("type", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Type { get; set;}
    
        /// <remarks/>
        [XmlAttribute( "n", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [System.ComponentModel.EditorBrowsable( System.ComponentModel.EditorBrowsableState.Never )]
        public string RawNString {
            get
            {
                return N?.ToString();
            }
            set
            {
                N = Parsers.ScaledDecimal.Parse( value );
            }
        }

        [XmlIgnore]
        public decimal? N { get; set; }

        /// <remarks/>
        [XmlAttribute( "m", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [System.ComponentModel.EditorBrowsable( System.ComponentModel.EditorBrowsableState.Never )]
        public string RawMString
        {
            get
            {
                return M?.ToString();
            }
            set
            {
                M = Parsers.ScaledDecimal.Parse( value );
            }
        }
    
        /// <remarks/>
        [XmlIgnore( )]
        public decimal? M { get; set; }

        /// <remarks/>
        [XmlAttribute( "name", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Name { get; set; }
    }
}