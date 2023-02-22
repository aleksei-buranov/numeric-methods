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
        }

        public Equation(double xMin, double xMax, double step)
        {
            XMin = xMin;
            XMax = xMax;
            Step = step;
        }

        public void SetValues(Equation equation2)
        {
            XMin = equation2.XMin;
            XMax = equation2.XMax;
            Step = equation2.Step;
        }

        public double XMin { get; private set; }

        public double XMax { get; private set; }

        public double Step { get; private set; }
    }
}
