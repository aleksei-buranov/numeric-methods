using CommunityToolkit.Mvvm.Input;
using NumericMethods.Models;
using NumericMethods.Service;
using System;

namespace NumericMethods.ViewModels
{
    internal class HalfDivisionerViewModel : BaseViewModel
    {
        private double _root;
        private double _boundary;
        private double _xMin;
        private double _xMax;
        private double _precision;

        public HalfDivisionerViewModel()
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

        public double Boundary
        {
            get => _boundary;
            private set
            {
                if (value.Equals(_boundary)) return;
                _boundary = value;
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
                CalculateRoot = x => Math.Sin(2 * x) - Math.Log(x)
            };
        }

        public RelayCommand CalculateRootWithHalfDivisionCommand => new RelayCommand(CalculateRootWithHalfDivision);

        private void CalculateRootWithHalfDivision()
        {
            (Root, Boundary) = Calculator.FindRootWithHalfDivision(Equation, XMin, XMax, Precision);
        }
    }
}
