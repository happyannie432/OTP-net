using System;
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
            var target = new AuthenticationService(new FakeProfile(), new FakeToken());
            var actual = target.IsValid("annie", "81000000");

            Assert.IsTrue(actual);
        }

        public class FakeProfile : IProfile
        {
            public string GetPassword(string account)
            {
                if (account == "annie")
                {
                    return "81";
                }

                throw new NotImplementedException();
            }
        }

        public class FakeToken : IToken
        {
            public string GetRandom(string account)
            {
                return "000000";
            }
        }
    }
}