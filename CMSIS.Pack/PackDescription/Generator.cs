using System.Xml.Linq;

namespace CMSIS.Pack.PackDescription
{
    public class Generator
    {
        internal static Generator ParseFrom( XElement arg )
        {
            return new Generator( );
        }
    }
}
