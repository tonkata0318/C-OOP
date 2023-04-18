using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public double height { get;private set; }
        public double width { get;private set; }
        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea()
        {
            return width* height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (height + width);
        }
        public override string Draw()
        {
            return $"Drawing {typeof(Rectangle).Name}";
        }
    }
}
