using CommunityToolkit.Mvvm.Input;
using NumericMethods.Models;
using NumericMethods.Service;
using System;
using System.Collections.ObjectModel;

namespace NumericMethods.ViewModels
{
    internal class LocalizerViewModel : BaseViewModel
    {
        private double _xMax;
        private double _xMin;
        private double _step;

        public LocalizerViewModel()
        {
            RootsCollection = new ObservableCollection<EquationRoots>();
            XMin = -10;
            XMax = 10;
            Step = 0.1;
            InitializeEquation();
        }

        public RelayCommand StartRootsCalculationCommand => new RelayCommand(StartRootsCalculation);

        public ObservableCollection<EquationRoots> RootsCollection { get; }
        public Equation Equation { get; private set; }

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

        public double Step
        {
            get => _step;
            set
            {
                if (value.Equals(_step)) return;
                _step = value;
                OnPropertyChanged();
            }
        }

        private void StartRootsCalculation()
        {
            RootsCollection.Clear();
            var roots = Calculator.FindEquationRoots(Equation, XMin, XMax, Step);
            foreach (var alternatingRoots in Calculator.FindAlternatingRoots(roots))
                RootsCollection.Add(alternatingRoots);
        }

        private void InitializeEquation()
        {
            Equation = new Equation()
            {
                StringValue = "F(X) = COS(X) - 0,1X",
                CalculateRoot = x => Math.Cos(x) - 0.1 * x
            };
        }
    }
}
