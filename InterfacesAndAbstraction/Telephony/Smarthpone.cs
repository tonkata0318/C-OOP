using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Telephony
{
    public class Smarthpone : ICallable, IBrowsable
    {
        public string Browse(string website)
        {
            if (!ValidateUrl(website))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {website}";
        }

        private bool ValidateUrl(string url)
            => url.All(c => !Char.IsDigit(c));

        public string Call(string phoneNUmber)
        {
            if (!ValidatePhoneNumber(phoneNUmber))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {phoneNUmber}";
        }
        private bool ValidatePhoneNumber(string phoneNumber)
            => phoneNumber.All(c => Char.IsDigit(c));

    }
}
