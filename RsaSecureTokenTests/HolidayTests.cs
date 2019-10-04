using System;
using NUnit.Framework;
using RsaSecureToken;

namespace RsaSecureTokenTests
{
    [TestFixture]
    public class HolidayTests
    {
        private HolidayForTest _holiday;

        [SetUp]
        public void Setup()
        {
            _holiday = new HolidayForTest();
        }

        [Test]
        public void IsChristmas()
        {
            SetToday(12, 25);
            ResponseShouldBe("Merry Christmas");
        }

        [Test]
        public void IsNotChristmas()
        {
            SetToday(11, 25);
            ResponseShouldBe("Hello");
        }

        private void ResponseShouldBe(string expected)
        {
            var result = _holiday.SayHello();
            Assert.AreEqual(expected, result);
        }

        private void SetToday(int month, int day)
        {
            _holiday.SetToday(new DateTime(2019, month, day));
        }

        public class HolidayForTest : Holiday
        {
            private DateTime _today;

            public void SetToday(DateTime today)
            {
                _today = today;
            }

            protected override DateTime GetToday()
            {
                return _today;
            }
        }
    }
}