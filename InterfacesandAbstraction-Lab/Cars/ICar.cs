using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public interface ICar
    {
        string Model { get; }
        string Color { get; }
        string Start()
        {
            return "Engine start";
        }
        string Stop()
        {
            return "Breaaak!";
        }
    }
}
