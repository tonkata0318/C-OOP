using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            var t = typeof(Person);
            var pi = t.GetProperty("FullName");
            var hasIsIdentity = Attribute.IsDefined(pi, typeof(MyRequiredAttribute));
            return hasIsIdentity;
        }
    }
}
