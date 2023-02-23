using CommunityToolkit.Mvvm.Input;
using NumericMethods.Models;
using NumericMethods.Service;
using System;

namespace NumericMethods.ViewModels
{
    internal class SimpleIteratorViewModel : BaseViewModel
    {
        private double _root;
        private double _x;
        private double _q;
        private double _precision;

        public SimpleIteratorViewModel()
        {
            InitializeEquation();
            X = 1.4;
            Q = 0.1;
            Precision = 0.000001;
        }

        public Equation Equation { get; set; }

        public RelayCommand CalculateRootWithSimpleIterationCommand =>
            new RelayCommand(CalculateRootWithSimpleIteration, () => Q < 1);

        public double X
        {
            get => _x;
            set
            {
                if (value.Equals(_x)) return;
                _x = value;
                OnPropertyChanged();
            }
        }

        public double Q
        {
            get => _q;
            set
            {
                if (value.Equals(_q)) return;
                _q = value;
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
                StringValue = "F(X) = X + 0.37(SIN(2X) - LN(X))",
                CalculateRoot = x => x + 0.37 * (Math.Sin(2 * x) - Math.Log(x))
            };
        }
        private void CalculateRootWithSimpleIteration()
        {
            Root = Calculator.FindRootWithSimpleIteration(Equation, X, Precision, Q);
        }
    }
}
