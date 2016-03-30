using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CMSIS.Pack.PackDescription
{
    internal static class XElementExtensions
    {
        internal static void ParseCollectionElements<T>( this XElement containerElement, XName descendantName, IList<T> list, Func<XElement, T> parser )
        {
            if( containerElement == null )
                return;

            foreach( var element in containerElement.Descendants( descendantName ) )
            {
                list.Add( parser( element ) );
            }
        }
    }
}
