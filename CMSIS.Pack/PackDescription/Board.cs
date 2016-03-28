using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CMSIS.Pack.PackDescription
{
    public class Board
    {
        internal static Board ParseFrom( XElement arg )
        {
            return new Board();
        }
    }
}
