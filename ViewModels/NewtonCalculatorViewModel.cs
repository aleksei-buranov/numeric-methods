using CommunityToolkit.Mvvm.Input;
using NumericMethods.Models;
using NumericMethods.Service;
using System;

namespace NumericMethods.ViewModels
{
    internal class NewtonCalculatorViewModel : BaseViewModel
    {
        private double _root;
        private double _xMin;
        private double _xMax;
        private double _precision;

        public NewtonCalculatorViewModel()
        {
            InitializeEquation();
            XMin = 1.3;
            XMax = 1.5;
            Precision = 0.0001;
        }

        public Equation Equation { get; set; }

        public double XMin
        {
            get => _xMin;
            set
            {
                if (value.Equals(_xMin)) return;
                _xMin = value;
                OnPropertyChanged();
            }
        }

        public double XMax
        {
            get => _xMax;
            set
            {
                if (value.Equals(_xMax)) return;
                _xMax = value;
                OnPropertyChanged();
            }
        }

        public double Precision
        {
            get => _precision;
            set
            {
                if (value.Equals(_precision)) return;
                _precision = value;
                OnPropertyChanged();
            }
        }

        public double Root
        {
            get => _root;
            private set
            {
                if (value.Equals(_root)) return;
                _root = value;
                OnPropertyChanged();
            }
        }

        private void InitializeEquation()
        {
            Equation = new Equation()
            {
                StringValue = "F(X) = SIN(2X) - LN(X)",
                CalculateRoot = x => Math.Sin(2 * x) - Math.Log(x),
                CalculateFirstDerivative = x => 2 * Math.Cos(2 * x) - Math.Pow(x, -1),
                CalculateSecondDerivative = x => Math.Pow(x, -2) - 4 * Math.Sin(2 * x),
            };
        }

        public RelayCommand CalculateRootWithNewtonMethodCommand => new RelayCommand(CalculateRootWithNewtonMethod);

        private void CalculateRootWithNewtonMethod()
        {
            Root = Calculator.FindRootWithNewtonMethod(Equation, XMin, XMax, Precision);
        }
    }
}
