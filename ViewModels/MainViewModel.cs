namespace NumericMethods.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            LocalizerViewModel = new LocalizerViewModel();
            HalfDivisionerViewModel = new HalfDivisionerViewModel();
            SimpleIteratorViewModel = new SimpleIteratorViewModel();
        }

        public LocalizerViewModel LocalizerViewModel { get; }
        public HalfDivisionerViewModel HalfDivisionerViewModel { get; }
        public SimpleIteratorViewModel SimpleIteratorViewModel { get; }
    }
}
