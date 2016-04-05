using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SemVer.NET;
using Sprache;

namespace UnitTests
{
    [TestClass]
    public class GrammarTests
    {
        private const string validIdentifierNonDigits = "ABCDEFGHIJKMLNOPQRSTUVWXYZabcdefghijkmlnopqrstuvwxyz-";

        // build metadata identifiers allow leading 0
        // but release identifiers don't (no explanation, given in spec on why...)

        [TestMethod]
        public void ValidBuildIdentifierParserTest( )
        {
            Assert.AreEqual( "1234", Grammar.BuildIdentifier.End( ).Parse( "1234" ) );
            Assert.AreEqual( "01234", Grammar.BuildIdentifier.End( ).Parse( "01234" ) );
            Assert.AreEqual( "A01234", Grammar.BuildIdentifier.End( ).Parse( "A01234" ) );
            Assert.AreEqual( "0ABCD", Grammar.BuildIdentifier.End( ).Parse( "0ABCD" ) );
            Assert.AreEqual( validIdentifierNonDigits, Grammar.BuildIdentifier.End( ).Parse( validIdentifierNonDigits ) );
        }

        [TestMethod]
        [ExpectedException( typeof( ParseException ) )]
        public void InvalidBuildIdentifierFailsTest( )
        {
            Assert.AreEqual( "A$BCD", Grammar.PrereleaseIdentifier.End( ).Parse( "A$BCD" ) );
        }

        [TestMethod]
        public void ValidPrereleaseIdentifierParserTest( )
        {
            Assert.AreEqual( "1234", Grammar.PrereleaseIdentifier.End( ).Parse( "1234" ) );
            Assert.AreEqual( "A01234", Grammar.PrereleaseIdentifier.End( ).Parse( "A01234" ) );
            Assert.AreEqual( validIdentifierNonDigits, Grammar.PrereleaseIdentifier.End( ).Parse( validIdentifierNonDigits ) );
        }

        [TestMethod]
        [ExpectedException( typeof( ParseException ) )]
        public void Leading0NumericPrereleaseIdentifierFailsTest( )
        {
            Assert.AreEqual( "01234", Grammar.PrereleaseIdentifier.End( ).Parse( "01234" ) );
        }

        [TestMethod]
        [ExpectedException( typeof( ParseException ) )]
        public void Leading0AlphaNumericPrereleaseIdentifierFailsTest( )
        {
            Assert.AreEqual( "0ABCD", Grammar.PrereleaseIdentifier.End( ).Parse( "0ABCD" ) );
        }

        [TestMethod]
        public void ParsingDotSeparatedBuildIdentifiersSucceedsTest( )
        {
            string[ ] parts =
            {
                "1234",
                "01234",
                "A01234",
                "0ABCD",
            };

            var parsedParts = Grammar.DotSeparatedBuildIdentifiers.End( ).Parse( string.Join( ".", parts ) ).ToArray( );
            Assert.AreEqual( parts.Length, parsedParts.Length );
            for( int i = 0; i < parts.Length; ++i )
            {
                Assert.AreEqual( parts[ i ], parsedParts[ i ], false, $"Mismatch at index: {i}" );
            }
        }

        [TestMethod]
        public void ParsingDotSeparatedReleaseIdentifiersSucceedsTest( )
        {
            string[ ] parts =
            {
                "1234",
                "A01234",
                "BCDEF",
            };

            var parsedParts = Grammar.DotSeparatedReleaseIdentifiers.End( ).Parse( string.Join( ".", parts ) ).ToArray( );
            Assert.AreEqual( parts.Length, parsedParts.Length );
            for( int i = 0; i < parts.Length; ++i )
            {
                Assert.AreEqual( parts[ i ], parsedParts[ i ], false, $"Mismatch at index: {i}" );
            }
        }

        [TestMethod]
        public void ParsingValidBuildNumberSucceeds( )
        {
            Assert.AreEqual( "87654", Grammar.BuildNumber.End( ).Parse( "87654" ) );
        }

        [TestMethod]
        [ExpectedException( typeof( ParseException ) )]
        public void ParsingLeading0BuildNumberFails( )
        {
            Assert.AreEqual( "087654", Grammar.BuildNumber.End( ).Parse( "087654" ) );
        }
    }
}
