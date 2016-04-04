using System;
using System.Xml;
using System.Xml.Serialization;

namespace CMSIS.Pack.PackDescription
{
    /// <remarks/>
    [Serializable( )]
    public partial class Release
    {
        /// <remarks/>
        [XmlAttribute( "version", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [System.ComponentModel.EditorBrowsable( System.ComponentModel.EditorBrowsableState.Never )]
        public string RawVersionString
        {
            get { return Version.ToString( ); }
            set
            {
                Version = SemanticVersion.Parse( value, SemanticVersionParseOptions.PatchOptional );
            }
        }

        [XmlIgnore]
        public SemanticVersion Version { get; set; }

        [XmlIgnore]
        public DateTime? Date { get; set; }

        /// <remarks>
        /// Some officially validated published PDSC files contain dates that
        /// do not conform to a proper XML specified DateTime string so this
        /// gets around it with a custom parser. The actual value is stored in
        /// the <see cref="Date"/> property.
        /// </remarks>
        [XmlAttribute("date", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [System.ComponentModel.EditorBrowsable( System.ComponentModel.EditorBrowsableState.Never )]
        public string RawDateString
        {
            get
            {
                return Date?.ToString("yyyy-MM-dd");
            }

            set
            {
                Date = DateTime.Parse( value );
            }
        }

        [XmlIgnore]
        public DateTime? Deprecated { get; set; }

        /// <remarks>
        /// Some officially validated published PDSC files contain dates that
        /// do not conform to a proper XML specified DateTime string so this
        /// gets around it with a custom parser. The actual value is stored in
        /// the <see cref="Date"/> property.
        /// </remarks>
        [XmlAttribute( "deprecated", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        [System.ComponentModel.EditorBrowsable( System.ComponentModel.EditorBrowsableState.Never )]
        public string RawDeprecatedString
        {
            get
            {
                return Deprecated?.ToString( "yyyy-MM-dd");
            }
            set
            {
                Deprecated = DateTime.Parse( value );
            }
        }

        /// <remarks/>
        [XmlAttribute( "replacement", Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Replacement { get; set; }

        /// <remarks/>
        [XmlText]
        public string Value { get; set; }
    }
}