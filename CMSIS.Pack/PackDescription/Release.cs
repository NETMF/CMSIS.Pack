using System.Xml.Linq;

namespace CMSIS.Pack.PackDescription
{
    public class Release
    {
        public SemanticVersion Version { get; set; }
        public string Description { get; set; }

        public static Release ParseFrom( XElement release )
        {
            return new Release()
                { Version = SemanticVersion.Parse( release.Attribute("version").Value )
                , Description = release.Value
                };
        }
    }
}
