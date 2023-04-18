using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        int minValue;
        int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        public override bool IsValid(object obj)
        {
            int objValue=int.Parse(obj.ToString());
            if (objValue>=minValue&&objValue<=maxValue)
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
