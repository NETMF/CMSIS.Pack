using System.Xml.Linq;

namespace CMSIS.Pack.PackDescription
{
    public class Keyword
    {
        internal static string ParseFrom( XElement keyword )
        {
            return keyword.Value;
        }
    }
}
