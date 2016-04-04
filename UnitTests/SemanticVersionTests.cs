using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMSIS.Pack;

namespace UnitTests
{
    [TestClass]
    public class SemanticVersionTests
    {
        [TestMethod]
        public void DefaultConstructorTest( )
        {
            var ver = new SemanticVersion( );
            Assert.AreEqual( 0, ver.Major );
            Assert.AreEqual( 0, ver.Minor );
            Assert.AreEqual( 0, ver.Patch );
            Assert.IsTrue( ver.IsValid );
            Assert.IsTrue( ver.IsDevelopment );
            Assert.IsTrue( ver.IsPrerelease );
            Assert.AreEqual( "0.0.0", ver.ToString() );
            VerifyToStringReverseParse( ver );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeMajorThrowsTest( )
        {
            var ver = new SemanticVersion( -1, 0, 0 );
        }

        [TestMethod]
        [ExpectedException( typeof( ArgumentOutOfRangeException ) )]
        public void NegativeMinorThrowsTest( )
        {
            var ver = new SemanticVersion(  0, -1, 0 );
        }

        [TestMethod]
        [ExpectedException( typeof( ArgumentOutOfRangeException ) )]
        public void NegativePatchThrowsTest( )
        {
            var ver = new SemanticVersion( 0, 0, -1 );
        }
        
        [TestMethod]
        public void NullPartsTest( )
        {
            var ver = new SemanticVersion( 0, 0, 0, null, null );
            Assert.AreEqual( 0, ver.Major );
            Assert.AreEqual( 0, ver.Minor );
            Assert.AreEqual( 0, ver.Patch );
            Assert.IsTrue( ver.IsValid );
            Assert.IsTrue( ver.IsDevelopment );
            Assert.IsTrue( ver.IsPrerelease );
            Assert.AreEqual( "0.0.0", ver.ToString( ) );
            VerifyToStringReverseParse( ver );
        }

        [TestMethod]
        [ExpectedException( typeof(ArgumentException))]
        public void InvalidPreReleasePartTest( )
        {
            var ver = new SemanticVersion( 0, 0, 0, new[ ] { "abcd", "12$", "bar" }, null );
        }

        [TestMethod]
        [ExpectedException( typeof( ArgumentException ) )]
        public void InvalidMetadataPartTest( )
        {
            var ver = new SemanticVersion( 0, 0, 0, new[ ] { "abcd" }, new[ ] { "abcd", "12$", "bar" } );
        }

        [TestMethod]
        public void PrereleasePartsOnlyTest( )
        {
            var ver = new SemanticVersion( 0, 1, 2, new[ ] { "abcd", "123", "bar" }, null );
            Assert.AreEqual( 0, ver.Major );
            Assert.AreEqual( 1, ver.Minor );
            Assert.AreEqual( 2, ver.Patch );
            Assert.IsTrue( ver.IsValid );
            Assert.IsTrue( ver.IsDevelopment );
            Assert.IsTrue( ver.IsPrerelease );
            Assert.AreEqual( 3, ver.PreReleaseParts.Count );
            Assert.AreEqual( "abcd", ver.PreReleaseParts[ 0 ] );
            Assert.AreEqual( "123", ver.PreReleaseParts[ 1 ] );
            Assert.AreEqual( "bar", ver.PreReleaseParts[ 2 ] );
            Assert.AreEqual( "0.1.2-abcd.123.bar", ver.ToString( ) );
            VerifyToStringReverseParse( ver );
        }

        [TestMethod]
        public void MetadataPartsOnlyTest( )
        {
            var ver = new SemanticVersion( 0, 1, 2, null, new[ ] { "abcd", "123", "bar" } );
            Assert.AreEqual( 0, ver.Major );
            Assert.AreEqual( 1, ver.Minor );
            Assert.AreEqual( 2, ver.Patch );
            Assert.IsTrue( ver.IsValid );
            Assert.IsTrue( ver.IsDevelopment );
            Assert.IsTrue( ver.IsPrerelease );
            Assert.AreEqual( 3, ver.BuildMetadata.Count );
            Assert.AreEqual( "abcd", ver.BuildMetadata[ 0 ] );
            Assert.AreEqual( "123", ver.BuildMetadata[ 1 ] );
            Assert.AreEqual( "bar", ver.BuildMetadata[ 2 ] );
            Assert.AreEqual( "0.1.2+abcd.123.bar", ver.ToString( ) );
            VerifyToStringReverseParse( ver );
        }

        [TestMethod]
        public void StaticParseTest()
        {
            var ver = SemanticVersion.Parse( "0.1.2-alpha.beta+foo-bar.baz" );
            Assert.AreEqual( 0, ver.Major );
            Assert.AreEqual( 1, ver.Minor );
            Assert.AreEqual( 2, ver.Patch );
            Assert.IsTrue( ver.IsValid );
            Assert.IsTrue( ver.IsDevelopment );
            Assert.IsTrue( ver.IsPrerelease );
            Assert.AreEqual( 2, ver.PreReleaseParts.Count );
            Assert.AreEqual( "alpha", ver.PreReleaseParts[ 0 ] );
            Assert.AreEqual( "beta", ver.PreReleaseParts[ 1 ] );
            Assert.AreEqual( 2, ver.BuildMetadata.Count );
            Assert.AreEqual( "foo-bar", ver.BuildMetadata[ 0 ] );
            Assert.AreEqual( "baz", ver.BuildMetadata[ 1 ] );
            Assert.AreEqual( "0.1.2-alpha.beta+foo-bar.baz", ver.ToString( ) );
            VerifyToStringReverseParse( ver );
        }

        [TestMethod]
        public void StaticParseDefaultPatchTest()
        {
            var ver = SemanticVersion.Parse( "0.1-alpha.beta+foo-bar.baz", SemanticVersionParseOptions.PatchOptional );
            Assert.AreEqual( 0, ver.Major );
            Assert.AreEqual( 1, ver.Minor );
            Assert.AreEqual( 0, ver.Patch );
            Assert.IsTrue( ver.IsValid );
            Assert.IsTrue( ver.IsDevelopment );
            Assert.IsTrue( ver.IsPrerelease );
            Assert.AreEqual( 2, ver.PreReleaseParts.Count );
            Assert.AreEqual( "alpha", ver.PreReleaseParts[ 0 ] );
            Assert.AreEqual( "beta", ver.PreReleaseParts[ 1 ] );
            Assert.AreEqual( 2, ver.BuildMetadata.Count );
            Assert.AreEqual( "foo-bar", ver.BuildMetadata[ 0 ] );
            Assert.AreEqual( "baz", ver.BuildMetadata[ 1 ] );
            Assert.AreEqual( "0.1.0-alpha.beta+foo-bar.baz", ver.ToString( ) );
            VerifyToStringReverseParse( ver );
        }

        [TestMethod]
        public void StaticParseSimpleMajorMinorOnlyTest( )
        {
            var ver = SemanticVersion.Parse( "2.1", SemanticVersionParseOptions.PatchOptional );
            Assert.AreEqual( 2, ver.Major );
            Assert.AreEqual( 1, ver.Minor );
            Assert.AreEqual( 0, ver.Patch );
            Assert.IsTrue( ver.IsValid );
            Assert.IsFalse( ver.IsDevelopment );
            Assert.IsFalse( ver.IsPrerelease );
            Assert.AreEqual( 0, ver.PreReleaseParts.Count );
            VerifyToStringReverseParse( ver );
        }

        [TestMethod]
        public void StaticParseNumericIdentifier()
        {
            var ver = SemanticVersion.Parse( "2.0.1-2.alpha", SemanticVersionParseOptions.PatchOptional );
            Assert.AreEqual( 2, ver.Major );
            Assert.AreEqual( 0, ver.Minor );
            Assert.AreEqual( 1, ver.Patch );
            Assert.IsTrue( ver.IsValid );
            Assert.IsFalse( ver.IsDevelopment );
            Assert.IsTrue( ver.IsPrerelease );
            Assert.AreEqual( 2, ver.PreReleaseParts.Count );
            Assert.AreEqual( "2", ver.PreReleaseParts[ 0 ] );
            Assert.AreEqual( "alpha", ver.PreReleaseParts[ 1 ] );
            Assert.AreEqual( 0, ver.BuildMetadata.Count );
            Assert.AreEqual( "2.0.1-2.alpha", ver.ToString( ) );
            VerifyToStringReverseParse( ver );
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void StaticParseDefaultPatchExceptionTest()
        {
            SemanticVersion.Parse( "0.1-alpha.beta+foo-bar.baz" );
        }

        [TestMethod]
        public void PrecedenceRule1Test()
        {
            //1.0.0 < 2.0.0 < 2.1.0 < 2.1.1
            var versions = new []
                { new SemanticVersion( 1, 0, 0 )
                , new SemanticVersion( 2, 0, 0 )
                , new SemanticVersion( 2, 1, 0 )
                , new SemanticVersion( 2, 1, 1 )
                };

            VerifyPrecedence( versions );
        }

        [TestMethod]
        public void PrecedenceRule2Test()
        {
            // 1.0.0-alpha < 1.0.0
            var versions = new [ ]
                { SemanticVersion.Parse( "1.0.0-alpha" )
                , new SemanticVersion( 1, 0, 0 )
                };

            VerifyPrecedence( versions );
        }

        [TestMethod]
        public void PrecedenceRule3Test()
        {
            // 1.0.0-alpha < 1.0.0-alpha.1 < 1.0.0-alpha.beta < 1.0.0-beta < 1.0.0-beta.2 < 1.0.0-beta.11 < 1.0.0-rc.1 < 1.0.0
            var versions = new [ ] 
                { SemanticVersion.Parse( "1.0.0-alpha" )
                , SemanticVersion.Parse( "1.0.0-alpha.1" ) 
                , SemanticVersion.Parse( "1.0.0-alpha.beta" )
                , SemanticVersion.Parse( "1.0.0-beta" )
                , SemanticVersion.Parse( "1.0.0-beta.2" )
                , SemanticVersion.Parse( "1.0.0-beta.11" )
                , SemanticVersion.Parse( "1.0.0-rc.1" )
                , SemanticVersion.Parse( "1.0.0" )
                };

            VerifyPrecedence( versions );
        }

        private static void VerifyPrecedence( SemanticVersion[ ] versions )
        {
            for( var i = 0; i < versions.Length - 1; ++i )
            {
                VerifyToStringReverseParse( versions[ i ] );
                Assert.IsTrue( versions[ i ].CompareTo( versions[ i + 1 ] ) < 0, string.Format( "FAILED Comparing '{0}' to '{1}", versions[ i ], versions[ i + 1 ] ) );
                Assert.IsTrue( versions[ i + 1 ].CompareTo( versions[ i ] ) > 0, string.Format( "FAILED Comparing '{1}' to '{0}", versions[ i ], versions[ i + 1 ] ) );
            }
            VerifyToStringReverseParse( versions[ versions.Length - 1 ] );
        }

        private static void VerifyToStringReverseParse( SemanticVersion ver )
        {
            SemanticVersion parsed;
            Assert.IsTrue( SemanticVersion.TryParse( ver.ToString( ), out parsed ) );
            Assert.IsTrue( parsed == ver, string.Format("FAILED equality check: '{0}'=='{1}'", parsed, ver ) );
            parsed = SemanticVersion.Parse( ver.ToString() );
            Assert.IsTrue( parsed == ver, string.Format("FAILED equality check: '{0}'=='{1}'", parsed, ver ) );
        }
    }
}
