﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count>0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Stack<string> AddRange(IEnumerable<string> collection)
        {
            foreach (var item in collection)
            {
                this.Push(item);
            }
            return this;
        }
    }
}
