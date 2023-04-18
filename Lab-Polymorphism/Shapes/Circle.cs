using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle:Shape
    {
        public double radius { get; private set; }
        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculatePerimeter()
        {
            return 2*Math.PI*radius;
        }

        public override double CalculateArea()
        {
            return Math.PI*Math.Pow(radius,2);
        }
        public override string Draw()
        {
            return $"Drawing {typeof(Circle).Name}";
        }
    }
}
