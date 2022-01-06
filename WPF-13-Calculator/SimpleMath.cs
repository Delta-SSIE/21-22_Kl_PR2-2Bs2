using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_13_Calculator
{
    enum Operation { Addition, Subtraction, Multiplication, Division, Percentage }
    static class SimpleMath
    {
        public static double Add(double num1, double num2)
        {
            return num1 + num2;
        }
        public static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }
        public static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }
        public static double Divide(double num1, double num2)
        {
            return num1 / num2;
        }
        public static double Percent(double num)
        {
            return num / 100;
        }
    }
}
