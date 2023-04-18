using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class DomesticAssistant : Robot
    {
        private const int intitalBateryCapacity = 20000 ;
        private const int intialConversionCapacity = 2000;
        public DomesticAssistant(string model) : base(model, intitalBateryCapacity, intialConversionCapacity)
        {
        }
    }
}
