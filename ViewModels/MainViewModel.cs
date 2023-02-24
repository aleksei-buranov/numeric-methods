namespace NumericMethods.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            LocalizerViewModel = new LocalizerViewModel();
            HalfDivisionerViewModel = new HalfDivisionerViewModel();
            SimpleIteratorViewModel = new SimpleIteratorViewModel();
            NewtonCalculatorViewModel = new NewtonCalculatorViewModel();
            LagrangeCalculatorViewModel = new LagrangeCalculatorViewModel();
            LinearInterpolationViewModel = new LinearInterpolationViewModel();
        }

        public LocalizerViewModel LocalizerViewModel { get; }
        public HalfDivisionerViewModel HalfDivisionerViewModel { get; }
        public SimpleIteratorViewModel SimpleIteratorViewModel { get; }
        public NewtonCalculatorViewModel NewtonCalculatorViewModel { get; }
        public LagrangeCalculatorViewModel LagrangeCalculatorViewModel { get; }
        public LinearInterpolationViewModel LinearInterpolationViewModel { get; }
    }
}
