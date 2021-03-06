
using System;
using System.Windows.Input;

namespace Publications.WPF.Commands.Base;

public abstract class Command : ICommand
{
    public static CommandBuilder Invoke(Action<object?> Execute) => new(Execute);

    public static CommandBuilder New() => new();

    //фабричный метод, который прячет реализацию
    public static ICommand New(Action<object?> Execute, Func<object?, bool>? CanExecute = null) => new RelayCommand(Execute, CanExecute);

    //тоже фабричный метод. Принимает делегаты для команды без параметров
    //из них делает нужные делегаты
    public static ICommand New(Action Execute, Func<bool>? CanExecute = null)
    {
        Action<object?> execute = _ => Execute();
        Func<object?, bool>? can_execute = CanExecute is null ? null : _ => CanExecute();
        return new RelayCommand(execute, can_execute);
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public virtual bool CanExecute(object? parameter) => true;

    public abstract void Execute(object? parameter);
}
