using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniDiFrameWork.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter|AttributeTargets.Field)]
    public class Named:Attribute
    {
		public Named(string name)
		{
			Name= name;
		}
		public string Name { get;}

	}
}
