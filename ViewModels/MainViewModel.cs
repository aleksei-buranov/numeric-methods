using NumericMethods.Models;

namespace NumericMethods.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Equation = new Equation();
            LocalizerViewModel = new LocalizerViewModel(this);
            HalfDivisionerViewModel = new HalfDivisionerViewModel(this);
        }

        public LocalizerViewModel LocalizerViewModel { get; }
        public HalfDivisionerViewModel HalfDivisionerViewModel { get; }

        public string VisibleEquation => Equation.StringValue;

        public double XMin
        {
            get => Equation.XMin;
            set => Equation.XMin = value;
        }

        public double XMax
        {
            get => Equation.XMax;
            set => Equation.XMax = value;
        }
        public double Step
        {
            get => Equation.Step;
            set => Equation.Step = value;
        }

        public double Precision
        {
            get => Equation.Precision;
            set => Equation.Precision = value;
        }
        public Equation Equation { get; }
    }
}
