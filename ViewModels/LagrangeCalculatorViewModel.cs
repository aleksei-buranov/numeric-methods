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
                new EquationRoots(0, 0.7272727272727273),
                new EquationRoots(1, 0.4545454545454546),
                new EquationRoots(2, 0.18181818181818188),
                new EquationRoots(7, -1.1818181818181817),
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
