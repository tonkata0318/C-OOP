﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Gorilla : Mammal
    {
        public string Name { get; set; }
        public Gorilla(string name) : base(name)
        {
            Name = name;
        }
    }
}
