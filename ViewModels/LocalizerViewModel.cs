using CommunityToolkit.Mvvm.Input;
using NumericMethods.Models;
using NumericMethods.Service;
using System.Collections.ObjectModel;

namespace NumericMethods.ViewModels
{
    internal class LocalizerViewModel : BaseViewModel
    {
        public LocalizerViewModel(MainViewModel parentViewModel)
        {
            ParentViewModel = parentViewModel;
            RootsCollection = new ObservableCollection<EquationRoots>();
        }

        private MainViewModel ParentViewModel { get; }

        public ObservableCollection<EquationRoots> RootsCollection { get; }

        public RelayCommand StartRootsCalculationCommand => new RelayCommand(StartRootsCalculation);

        private void StartRootsCalculation()
        {
            RootsCollection.Clear();
            var roots = Calculator.FindEquationRoots(ParentViewModel.Equation);
            foreach (var alternatingRoots in Calculator.FindAlternatingRoots(roots))
                RootsCollection.Add(alternatingRoots);
        }
    }
}
