﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters
{
    public class SoulMaster : DarkWizard
    {
        public SoulMaster(string userName, int level) : base(userName, level)
        {
            UserName = userName;
            Level = level;
        }
    }
}
