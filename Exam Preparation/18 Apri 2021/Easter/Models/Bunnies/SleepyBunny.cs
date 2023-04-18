﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int initalSleepyBunnyenergy = 50;
        public SleepyBunny(string name) : base(name, initalSleepyBunnyenergy)
        {
        }
    }
}
