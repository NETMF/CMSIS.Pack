using System.Xml.Linq;

namespace CMSIS.Pack.PackDescription
{
    public class TaxonomyDescription
    {
        public string ComponentClass { get; set; }
        public string ComponentGroup { get; set; }
        public string DocumentationPath { get; set; }
        public string Generator { get; set; }

        internal static TaxonomyDescription ParseFrom( XElement element )
        {
            return new TaxonomyDescription()
            { ComponentClass = element.Attribute( AttributeNames.ComponentClass ).Value
            , ComponentGroup = element.Attribute( AttributeNames.ComponentGroup )?.Value
            , DocumentationPath = element.Attribute( AttributeNames.Doc )?.Value
            , Generator = element.Attribute( AttributeNames.Generator )?.Value
            };
        }
    }
}
