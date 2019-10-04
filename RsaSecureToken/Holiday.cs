using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateTime = System.DateTime;

namespace RsaSecureToken
{
    public class Holiday
    {
        public string SayHello()
        {
            var today = GetToday();
            return today.Day == 25 && today.Month == 12 ? "Merry Christmas" : "Hello";
        }

        //add extract and override 
        protected virtual DateTime GetToday()
        {
            return DateTime.Today;
        }
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
