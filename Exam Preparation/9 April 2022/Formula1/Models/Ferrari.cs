﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
{
    public class Ferrari : FormulaOneCar
    {
        public Ferrari(string model, int horsePower, double engineDisplacement) : base(model, horsePower, engineDisplacement)
        {
        }
    }
}
