using NSubstitute;
using NUnit.Framework;
using RsaSecureToken;
using Assert = NUnit.Framework.Assert;

namespace RsaSecureTokenTests
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        [Test()]
        public void is_valid()
        {
            var profile = Substitute.For<IProfile>();
            profile.GetPassword("annie").Returns("81");

            var token = Substitute.For<IToken>();
            token.GetRandom(Arg.Any<string>()).Returns("000000");
            // token.GetRandom("").Returns("000000"); same

            var target = new AuthenticationService(profile, token);
            var actual = target.IsValid("annie", "81000000");

            Assert.IsTrue(actual);
        }
    }
}