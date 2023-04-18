using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    static class Validator
    {
        public static bool IsValid(object obj)
        {
            Person person=obj as Person;
            MyRangeAttribute range = new MyRangeAttribute(12,90);
            MyRequiredAttribute requiredAttribute = new MyRequiredAttribute();
            if (range.IsValid(person.Age)==true&&requiredAttribute.IsValid(person.FullName)==true&&string.IsNullOrWhiteSpace(person.FullName)==false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
