using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal static class Calculator
    {
        [Obsolete("this mathod is obsolete use new method Add instead")]
        public static int Addition(int a, int b)
        {
            int sum;
            sum = a + b;
            return sum;
        }

        [Obsolete("this mathod is obsolete use new method Sub instead")]
        public static int Substruction(int a, int b)
        {
            int difference;
            difference = a - b;
            return difference;
        }

        [Obsolete("this mathod is obsolete use new method Mul instead")]
        public static int Multiplying(int a, int b)
        {
            int product = 0;
            for (int i = 0; i < b; i++)
            {
                product += a;
            }
            return product;
        }

        [Obsolete("this mathod is obsolete use new method Div instead", true)]
        //only returning values from 0 to 10
        public static int Division(int a, int b)
        {
            if (a == 0)
            {
                return 0;
            }
            int product = 0;
            for (int i = 1; i <= 10; i++)
            {
                product = Multiplying(b, i);
                if (product == a)
                {
                    return i;
                }
            }
            return -1;
        }

        public static double Add(double a, double b)
        {
            return a + b;
        }
        public static double Sub(double a, double b)
        {
            return a - b;
        }
        public static double Mul(double a, double b)
        {
            return a * b;
        }
        public static double Div(double a, double b)
        {
            return a / b;
        }
    }
}
