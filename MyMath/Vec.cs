using System;

namespace MyMath
{
    public class Vec
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vec(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vec Multiply(double num)
        {
            if (double.IsNaN(num))
                throw new ArgumentException("Given argument is not a number");

            return new Vec(this.X * num, this.Y * num);
        }
        public override string ToString()
        {
            return $"Vector ({this.X}, {this.Y})";
        }
        /// <summary>
        /// Vector magnitude
        /// </summary>
        /// <returns></returns>
        public double Mag()
        {
            return Math.Sqrt(X * X + Y * Y);
        }
    }
}
