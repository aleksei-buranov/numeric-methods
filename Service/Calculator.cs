using NumericMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NumericMethods.Service
{
    internal class Calculator
    {
        public static List<EquationRoots> FindEquationRoots(Equation equation, double xMin, double xMax, double step)
        {
            var roots = new List<EquationRoots>();

            for (double x = xMin; x < xMax; x += step)
            {
                var y = equation.CalculateRoot(x);
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

        public static Tuple<double, double> FindRootWithHalfDivision(Equation equation,
            double xmin, double xmax, double precision)
        {
            var start = xmin;
            var end = xmax;
            do
            {
                var half = (start + end) / 2;

                if (equation.CalculateRoot(start) * equation.CalculateRoot(half) < 0)
                    end = half;
                else
                    start = half;

            } while (end - start > precision);

            return new Tuple<double, double>((start + end) / 2, (end - start) / 2);
        }

        public static double FindRootWithSimpleIteration(Equation equation,
            double x, double precision, double q)
        {
            double p, a = precision * (1 - q) / q;
            do
            {
                var y = equation.CalculateRoot(x);
                p = x - y;
                x = y;

            } while (Math.Abs(p) > a);

            return x;
        }

        public static double FindRootWithNewtonMethod(Equation equation,
            double a, double b, double precision)
        {
            var x = equation.CalculateRoot(a) * equation.CalculateSecondDerivative(a) > 0 ? a : b;
            var product = equation.CalculateRoot(x) * equation.CalculateSecondDerivative(x);
            var derivative = equation.CalculateFirstDerivative(x);
            if (derivative == 0 || Math.Abs(product) >= Math.Pow(derivative, 2))
                return double.NaN;
            double currentPrecision, root;
            do
            {
                root = equation.CalculateRoot(x);
                currentPrecision = root / equation.CalculateFirstDerivative(x);
                x -= currentPrecision;
            } while (!(Math.Abs(currentPrecision) < precision && Math.Abs(root) <= precision));

            return x;
        }

        public static double FindLagrangeInterpolationValue(IEnumerable<EquationRoots> nodes, double desiredX)
        {
            var nodeList = nodes.ToList();

            double fX = 0;
            foreach (var node in nodeList)
            {
                double polynomialTermPart = nodeList.Where(innerNode => innerNode != node)
                    .Aggregate<EquationRoots, double>(1, (current, innerNode)
                        => current * ((desiredX - innerNode.X) / (node.X - innerNode.X)));
                fX += node.Y * polynomialTermPart;
            }

            return fX;
        }

        public static double FindLinearInterpolationValue(IEnumerable<EquationRoots> nodes, double desiredX)
        {
            var nodeList = nodes.ToList();

            int neededIndex = 0, tempIndex = 0;
            if (desiredX < nodeList.First().X)
                neededIndex = 1;
            else if (desiredX > nodeList.Last().X)
                neededIndex = nodeList.Count - 1;
            else
                while (tempIndex < nodeList.Count)
                {
                    tempIndex++;
                    if (desiredX >= nodeList[tempIndex - 1].X && desiredX <= nodeList[tempIndex].X)
                    {
                        neededIndex = tempIndex;
                        break;
                    }

                }

            var a = (nodeList[neededIndex].Y - nodeList[neededIndex - 1].Y)
                    / (nodeList[neededIndex].X - nodeList[neededIndex - 1].X);
            var b = nodeList[neededIndex - 1].Y - a * nodeList[neededIndex - 1].X;
            var fX = a * desiredX + b;

            return fX;
        }
    }
}
