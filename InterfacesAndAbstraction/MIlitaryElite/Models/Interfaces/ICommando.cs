using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIlitaryElite.Models.Interfaces
{
    public interface ICommando
    {
        HashSet<IMissions> missions { get; }
    }
}
