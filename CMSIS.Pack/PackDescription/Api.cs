using System.Collections.Generic;
using System.Xml.Linq;

namespace CMSIS.Pack.PackDescription
{
    public class Api
    {
        public Api()
        {
            Files = new List<File>();
        }

        public string ComponentClass { get; set; }
        public string ComponentGroup { get; set; }
        public bool IsExclusive { get; set; }
        public SemanticVersion Version { get; set; }
        public string Description { get; set; }
        public IList<File> Files { get; }

        internal static Api ParseFrom( XElement arg )
        {
            var retVal = new Api()
            { ComponentClass = arg.Attribute( AttributeNames.ComponentClass ).Value
            , ComponentGroup = arg.Attribute( AttributeNames.ComponentGroup ).Value
            , IsExclusive = 0 != int.Parse( arg.Attribute( AttributeNames.Exclusive )?.Value ?? "0" )
            , Description = arg.Element( ElementNames.Description )?.Value
            };

            var versionStr = arg.Attribute( AttributeNames.ComponentApiVersion )?.Value;
            if( !string.IsNullOrWhiteSpace( versionStr ) )
                retVal.Version = SemanticVersion.Parse(  versionStr );

            var filesElement = arg.Element( ElementNames.Files );
            filesElement.ParseCollectionElements( ElementNames.File, retVal.Files, File.ParseFrom );
            return retVal;
        }
    }
}
