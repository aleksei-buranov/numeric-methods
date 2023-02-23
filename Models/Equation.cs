using System;

namespace NumericMethods.Models
{
    public class Equation
    {
        public string StringValue { get; set; }
        public Func<double, double> CalculateRoot { get; set; }

    }
}
