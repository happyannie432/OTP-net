using NSubstitute;
using NUnit.Framework;
using RsaSecureToken;
using Assert = NUnit.Framework.Assert;

namespace RsaSecureTokenTests
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private IProfile _profile;
        private IToken _token;
        private AuthenticationService _target;

        [SetUp]
        public void SetUp()
        {
            _profile = Substitute.For<IProfile>();
            _token = Substitute.For<IToken>();
            _target = new AuthenticationService(_profile, _token);
        }
        // ctrl w and d
        [Test()]
        public void is_valid()
        {
            GivenPassword("annie", "81");
            GivenRandom("000000");
            ShouldBeValid("annie", "81000000");
        }

        [Test()]
        public void is_invalid()
        {
            GivenPassword("annie", "81");
            GivenRandom("000000");
            ShouldBeValid("annie", "81000000");
        }

        private void ShouldBeValid(string account, string password)
        {
            var actual = _target.IsValid(account, password);
            Assert.IsTrue(actual);
        }

        private void GivenRandom(string returnThis)
        {
            _token.GetRandom(Arg.Any<string>()).Returns(returnThis);
        }

        private void GivenPassword(string account, string password)
        {
            _profile.GetPassword(account).Returns(password);
        }
    
    }
}