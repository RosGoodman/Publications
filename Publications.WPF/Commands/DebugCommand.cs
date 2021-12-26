
using Publications.WPF.Commands.Base;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Publications.WPF.Commands;

/// <summary> Декоратор. </summary>
public class DebugCommand : Command, ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add => _baseCommand.CanExecuteChanged += value;

        remove => _baseCommand.CanExecuteChanged -= value;
    }

    private readonly ICommand _baseCommand;

    public DebugCommand(ICommand baseCommand)
    {
        if(baseCommand is DebugCommand debug_command)
            _baseCommand = debug_command._baseCommand;
        else
            _baseCommand = baseCommand;
    }

    public override bool CanExecute(object? parameter)
    {
        var can_execute = _baseCommand.CanExecute(parameter);
        return can_execute;
    }

    public override void Execute(object? parameter)
    {
        Debug.WriteLine("Вызов команды {0} {1}", _baseCommand.GetHashCode(), _baseCommand.GetType());
        var timer = Stopwatch.StartNew();
        _baseCommand.Execute(parameter);
        Debug.WriteLine("Вызов команды {0} {1} завершен за {2:0.00}сек.",
            _baseCommand.GetHashCode(), _baseCommand.GetType(),
            timer.Elapsed.TotalSeconds);
    }
}
