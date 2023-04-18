using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        public double Length
        {
            get { return this.length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                length= value;
            }
        }
        private double width;
        public double Width
        {
            get { return this.width; }
           private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                width= value;
            }
        }
        private double height;
        public double Height
        { get { return this.height; }
           private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                height = value;
            }
        }
        public Box(double length, double width,double height)
        {
            Height= height;
            Length = length;
            Width = width;
        }
        public double SurfaceArea()
        {
            double first =  (length * width);
            double second = (length* height);
            double third =(height * width);
            double sum=2*(first+ second + third);
            return sum;
        }
        public double LateralSurfaceArea()
        {
            double sum = 2 * (length + width) * height;
            return sum;
        }
        public double Volume()
        {
            double sum = length * width * height;
            return sum;
        }
    }
}

