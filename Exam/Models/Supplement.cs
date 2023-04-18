using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Supplement : ISupplement
    {
		public Supplement(int interfaceStandard,int bateryUsage)
		{
			InterfaceStandard= interfaceStandard;
			BatteryUsage=bateryUsage;
		}
		private int interfaceStandart;

		public int InterfaceStandard
		{
			get { return interfaceStandart; }
			private set { interfaceStandart = value; }
		}


		private int bateryUsage;

		public int BatteryUsage
		{
			get { return bateryUsage; }
			private set { bateryUsage = value; }
		}

	}
}
