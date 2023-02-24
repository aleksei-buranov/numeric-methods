using CommunityToolkit.Mvvm.Input;
using NumericMethods.Models;
using NumericMethods.Service;
using System.Collections.ObjectModel;

namespace NumericMethods.ViewModels
{
    internal class LagrangeCalculatorViewModel : BaseViewModel
    {
        private double _desiredX;
        private double _fx;

        public LagrangeCalculatorViewModel()
        {
            NodeCollection = new ObservableCollection<EquationRoots>(new[]
            {
                new EquationRoots(-1, 1),
                new EquationRoots(2, -2),
                new EquationRoots(5, 3),
                new EquationRoots(6, 7),
                new EquationRoots(8, 2),
                new EquationRoots(10, -2),
            });
            DesiredX = 2.5;
        }

        public ObservableCollection<EquationRoots> NodeCollection { get; }

        public double DesiredX
        {
            get => _desiredX;
            set
            {
                if (value.Equals(_desiredX)) return;
                _desiredX = value;
                OnPropertyChanged();
            }
        }

        public double Fx
        {
            get => _fx;
            private set
            {
                if (value.Equals(_fx)) return;
                _fx = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand CalculateLagrangeInterpolationCommand => new RelayCommand(CalculateLagrangeInterpolation);

        private void CalculateLagrangeInterpolation()
        {
            Fx = Calculator.FindLagrangeInterpolationValue(NodeCollection, DesiredX);
        }
    }
}
