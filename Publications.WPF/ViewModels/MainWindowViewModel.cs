

using Publications.WPF.ViewModels.Base;

namespace Publications.WPF.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _title = "Главное окно программы.";

        public string Title { get => _title; set => _title = value; }
    }
}
