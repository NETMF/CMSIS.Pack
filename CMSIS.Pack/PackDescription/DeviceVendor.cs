using System;
using System.Linq;
using Sprache;

namespace CMSIS.Pack.PackDescription
{
    /// <summary>Name value pair for enumerated Device vendors</summary>
    /// <remarks>
    /// Some officially published and supposedly validated PDSC files,
    /// Contain strings that don't match the published schema, typically
    /// case mismatches. Others contain vendors that aren't listed in 
    /// the official schema or public documentation. This gracefully
    /// handles reading such vendor names without triggering XML parsing
    /// errors. Unfortunately, vendors not listed in the official schema
    /// will still fail to validate once written back. This is not something
    /// that can be fixed with a transform. At best the validator could be
    /// enhanced to add the known offending vendor,id pairs before performing
    /// the validation, either at runtime or by using a modified XSD for
    /// validations
    /// </remarks>
    public class DeviceVendor 
        : IEquatable<DeviceVendor>
    {
        public DeviceVendor( string name, DeviceVendorEnum id )
        {
            // NOTE: the name and value are intentionally not
            // validated against the enumeration since some
            // real world PDSC files contain names that don't
            // match exactly.
            Name = name;
            Id = id;
        }

        public string Name { get; }
        public DeviceVendorEnum Id { get; }

        public override string ToString( ) => $"{Name}:{( int )Id}";

        public bool Equals( DeviceVendor other )
        {
            if( other == null )
                return false;

            if( 0 != string.Compare( Name, other.Name, StringComparison.InvariantCultureIgnoreCase ) )
                return false;

            return Id == other.Id;
        }

        public override bool Equals( object obj )
        {
            var dv = obj as DeviceVendor;
            if( dv == null )
                return base.Equals( obj );
            else
                return Equals( dv );
        }

        public override int GetHashCode( )
        {
            if( !HashCode.HasValue )
                HashCode = Name.ToLowerInvariant().GetHashCode() ^ Id.GetHashCode();

            return HashCode.Value;
        }

        private int? HashCode;

        public static DeviceVendor Parse( string txt ) => Parser.Parse( txt );

        private static Parser<DeviceVendor> Parser = from name in Sprache.Parse.CharExcept(':').AtLeastOnce().Token().Text()
                                                     from colon in Sprache.Parse.Char(':')
                                                     from value in Sprache.Parse.Digit.Repeat( 1, 8 ).Token().Text()
                                                     select new DeviceVendor( name, (DeviceVendorEnum)int.Parse(value));
    }
}
