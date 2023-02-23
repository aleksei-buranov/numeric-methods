using CommunityToolkit.Mvvm.Input;
using NumericMethods.Service;
using System;

namespace NumericMethods.ViewModels
{
    internal class HalfDivisionerViewModel : BaseViewModel
    {
        private double _root;
        private double _boundary;

        public HalfDivisionerViewModel(MainViewModel parentViewModel)
        {
            ParentViewModel = parentViewModel;
        }

        private MainViewModel ParentViewModel { get; }

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

        public RelayCommand CalculateRootWithHalfDivisionCommand => new RelayCommand(CalculateRootWithHalfDivision);

        private void CalculateRootWithHalfDivision()
        {
            (Root, Boundary) = Calculator.FindRootWithHalfDivision(ParentViewModel.Equation);
        }
    }
}
