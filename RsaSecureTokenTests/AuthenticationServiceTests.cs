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
        private ILogger _logger;

        [SetUp]
        public void SetUp()
        {
            _profile = Substitute.For<IProfile>();
            _token = Substitute.For<IToken>();
            _logger = Substitute.For<ILogger>();
            _target = new AuthenticationService(_profile, _token, _logger);
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

        [Test()]
        public void IsLogWhenInvalid()
        {
            GivenPassword("annie", "77");
            GivenRandom("000000");
            ShouldBeInValid("annie", "81000000");
            ShouldLogInfo("annie");
        }

        private void ShouldLogInfo(string account)
        {
            //don't log too detail. if the log change the test will failed.  
            _logger.Received(1).Info(Arg.Is<string>(m => m.Contains(account)));
        }

        private void ShouldBeValid(string account, string password)
        {
            var actual = _target.IsValid(account, password);
            Assert.IsTrue(actual);
        }
        private void ShouldBeInValid(string account, string password)
        {
            var actual = _target.IsValid(account, password);
            Assert.IsFalse(actual);
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