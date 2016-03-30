using System;
using System.Xml.Linq;
using Sprache;

namespace CMSIS.Pack.PackDescription
{
    public class Release
    {
        public SemanticVersion Version { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public static Release ParseFrom( XElement release )
        {
            var retVal = new Release()
                { Version = SemanticVersion.Parse( release.Attribute( AttributeNames.Version ).Value )
                , Description = release.Value
                };

            var dateString = release.Attribute( AttributeNames.Date )?.Value;
            if( !string.IsNullOrWhiteSpace( dateString ) )
                retVal.Date = Parsers.DateTime.Parse( dateString );

            return retVal;
        }
    }
}
