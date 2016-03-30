using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CMSIS.Pack.PackDescription
{
    internal static class ElementNames
    {
        internal static XName Package = XName.Get("package");
        
        internal static XName Taxonomy = XName.Get("taxonomy");
        internal static XName Vendor = XName.Get("vendor");
        internal static XName Name = XName.Get("name");
        internal static XName Description = XName.Get("description");
        internal static XName Url = XName.Get("url");
        internal static XName SupportContact = XName.Get("supportContact");
        internal static XName License = XName.Get("license");

        internal static XName Keywords = XName.Get("keywords");
        internal static XName Keyword = XName.Get("keyword");

        internal static XName Releases = XName.Get("releases");
        internal static XName Release = XName.Get("release");

        internal static XName Generators = XName.Get("generators");
        internal static XName Generator = XName.Get("generator");

        internal static XName Devices = XName.Get("devices");
        internal static XName Family = XName.Get("family");

        internal static XName Boards = XName.Get("boards");
        internal static XName Board = XName.Get("board");

        internal static XName Apis = XName.Get("apis");
        internal static XName Api = XName.Get("api");

        internal static XName Conditions = XName.Get("conditions");
        internal static XName Condition = XName.Get("condition");

        internal static XName Examples = XName.Get("examples");
        internal static XName Example = XName.Get("example");

        internal static XName Components = XName.Get("components");
        internal static XName Component = XName.Get("component");

        internal static XName Files = XName.Get("files");
        internal static XName File = XName.Get("file");
    }

    internal static class AttributeNames
    {
        internal static XName Description = XName.Get("description");
        internal static XName ComponentGroup = XName.Get("Cgroup");
        internal static XName ComponentClass = XName.Get("Cclass");
        internal static XName Version = XName.Get("version");
        internal static XName Date = XName.Get("date");
        internal static XName ComponentApiVersion = XName.Get( "CapiVersion");
        internal static XName Doc = XName.Get("doc");
        internal static XName Generator = XName.Get("generator");
        internal static XName Name = XName.Get("name");
        internal static XName Category = XName.Get("category");
        internal static XName Attribute = XName.Get("attr");
        internal static XName Condition = XName.Get("condition");
        internal static XName Select = XName.Get("select");
        internal static XName SourcePath = XName.Get("src");
        internal static XName Exclusive = XName.Get("exclusive");
    }
}
