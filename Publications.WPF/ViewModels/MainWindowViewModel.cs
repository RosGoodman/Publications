
using Publications.WPF.Commands;
using Publications.WPF.Commands.Base;
using Publications.WPF.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace Publications.WPF.ViewModels;

internal class MainWindowViewModel : ViewModel
{
    private string _title = "Главное окно программы.";

    public string Title { get => _title; set => _title = value; }



    #region MessageText

    /// <summary> Текст сообщения. </summary>
    private string _MessageText = "";

    /// <summary> Текст сообщения. </summary>
    public string MessageText { get => _MessageText; set => Set(ref _MessageText, value); }

    #endregion



    #region ShowMessageCommand - отображение диалога с пользователем

    private ICommand? _ShowMessageCommand;

    //public ICommand ShowMessageCommand => _ShowMessageCommand ??= new RelayCommand(OnShowMessageCommandExecuted, CanShowMessageCommandExecute);
    public ICommand ShowMessageCommand => _ShowMessageCommand ??= Command.New(OnShowMessageCommandExecuted, CanShowMessageCommandExecute);

    private static bool CanShowMessageCommandExecute(object? parameter) => parameter switch
    {
        string msg => msg.Length > 0,
        _ => parameter is not null
    };

    private static void OnShowMessageCommandExecuted(object? parameter)
    {
        if (parameter is not { } value) return;

        var mesage = value as string ?? value.ToString();

        MessageBox.Show(mesage, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    #endregion

    #region CloseMainWindowCommand - команда закрытия главного окна

    private ICommand _CloseMainWindowCommand;

    public ICommand CloseMainWindowCommand => _CloseMainWindowCommand ??= Command.New(OnCloseMainWidowCommandExecute);

    private void OnCloseMainWidowCommandExecute()
    {
        Application.Current.MainWindow?.Close();
    }

    #endregion
}
