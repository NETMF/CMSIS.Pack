using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CMSIS.Pack.PackDescription
{
    public class Api
    {
        internal static Api ParseFrom( XElement arg )
        {
            return new Api();
        }
    }
}
