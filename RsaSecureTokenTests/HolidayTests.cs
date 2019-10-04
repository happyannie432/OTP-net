using System;
using NUnit.Framework;
using RsaSecureToken;

namespace RsaSecureTokenTests
{
    [TestFixture]
    public class HolidayTests
    {
        [Test]
        public void IsChristmas()
        {
            var holiday = new HolidayForTest();
            holiday.SetToday(new DateTime(2019, 12, 25));
            var result = holiday.SayHello();
            Assert.AreEqual("Merry Christmas", result);
        }

        [Test]
        public void IsNotChristmas()
        {
            var holiday = new HolidayForTest();
            holiday.SetToday(new DateTime(2019, 12, 24));
            var result = holiday.SayHello();
            Assert.AreEqual("Hello", result);
        }
    }
}