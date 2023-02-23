using NumericMethods.Models;
using System.Collections.Generic;
using System.Linq;

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

        public static List<EquationRoots> FindAlternatingRoots(List<EquationRoots> roots)
        {
            var result = new List<EquationRoots>();
            if (roots?.Count() < 2)
                return result;

            for (int i = 1; i < roots.Count; i++)
            {
                if (roots[i].Y * roots[i - 1].Y >= 0) continue;
                result.Add(roots[i - 1]);
                result.Add(roots[i]);
            }

            return result;
        }
    }
}
