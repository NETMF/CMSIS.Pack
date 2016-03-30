using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CMSIS.Pack.PackDescription
{
    enum FileCategory
    {
        Doc,
        Header,
        Include,
        Library,
        Object,
        Source,
        SourceC,
        SourceCPP,
        SourceAsm,
        LinkerScript,
        Utility,
        Image,
        Other
    }

    enum FileAttribute
    {
        Config,
        Template
    }

    public class File
    {
        internal static File ParseFrom( XElement arg )
        {
            return new File();
        }
    }
}
