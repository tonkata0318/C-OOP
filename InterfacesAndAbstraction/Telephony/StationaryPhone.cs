using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNUmber)
        {
            if (!ValidatePhoneNumber(phoneNUmber))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Dialing... {phoneNUmber}";
        }
        private bool ValidatePhoneNumber(string phoneNumber)
            => phoneNumber.All(c => Char.IsDigit(c));
        
    }
}
