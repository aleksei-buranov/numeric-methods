using System;

namespace NumericMethods.Models
{
    public class Equation
    {
        public static string StringValue = "F(X) = COS(X) - 0,1X";
        public static double CalculateRoot(double x)
        {
            return Math.Cos(x) - 0.1 * x;
        }

        public Equation()
        {
            XMin = -10;
            XMax = 10;
            Step = 0.1;
            Precision = 0.0001;
        }

        public Equation(double xMin, double xMax, double step, double precision)
        {
            XMin = xMin;
            XMax = xMax;
            Step = step;
            Precision = precision;
        }

        public double XMin { get; set; }

        public double XMax { get; set; }

        public double Step { get; set; }
        public double Precision { get; set; }
    }
}
