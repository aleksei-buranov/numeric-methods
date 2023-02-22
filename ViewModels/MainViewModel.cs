namespace NumericMethods.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            LocalizerViewModel = new LocalizerViewModel();
        }

        public LocalizerViewModel LocalizerViewModel { get; }
    }
}
