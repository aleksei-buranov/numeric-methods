using CommunityToolkit.Mvvm.Input;
using NumericMethods.Models;
using NumericMethods.Service;
using System.Collections.ObjectModel;

namespace NumericMethods.ViewModels
{
    internal class LocalizerViewModel : BaseViewModel
    {
        public LocalizerViewModel()
        {
            RootsCollection = new ObservableCollection<EquationRoots>();
            Equation = new Equation();
        }

        public ObservableCollection<EquationRoots> RootsCollection { get; }
        public Equation Equation { get; }

        public string VisibleEquation => Equation.StringValue;

        public double XMin { get; set; } = -10;
        public double XMax { get; set; } = 10;
        public double Step { get; set; } = 0.1;

        public RelayCommand StartRootsCalculationCommand => new RelayCommand(StartRootsCalculation);

        private void StartRootsCalculation()
        {
            Equation.SetValues(new Equation(XMin, XMax, Step));
            RootsCollection.Clear();
            var roots = Calculator.FindEquationRoots(Equation);
            foreach (var alternatingRoots in Calculator.FindAlternatingRoots(roots))
                RootsCollection.Add(alternatingRoots);
        }
    }
}
