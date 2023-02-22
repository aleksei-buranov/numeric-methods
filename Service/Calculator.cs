using NumericMethods.Models;
using System.Collections.Generic;

namespace NumericMethods.Service
{
    internal class Calculator
    {
        public static List<EquationRoots> FindEquationRoots(Equation equation)
        {
            var roots = new List<EquationRoots>();

            for (double x = equation.XMin; x < equation.XMax; x += equation.Step)
            {
                var y = Equation.CalculateRoot(x);
                roots.Add(new EquationRoots(x, y));
            }

            return roots;
        }
    }
}
