

using System;
using System.Windows.Input;

namespace Publications.WPF.Commands.Base;

public class CommandBuilder
{
    private Action<object?> _execute;
    private Func<object?, bool> _canExecute;
    private bool _debug;

    public CommandBuilder() { }

    public CommandBuilder(Action<object?> Execute) => _execute = Execute;

    public CommandBuilder When(Func<object?, bool> canExecute)
    {
        _canExecute = canExecute;
        return this;
    }

    public CommandBuilder Invoke(Action<object?> execute)
    {
        _execute += execute; 
        return this; 
    }

    public CommandBuilder Debug()
    {
        _debug = true;
        return this;
    }

    public ICommand Build()
    {
        var result = new RelayCommand(_execute!, _canExecute);
        //если включен флаг debug, то создается debugCommand и передается созданная только что команда.
        return _debug ? new DebugCommand(result) : result;
    }

    public static implicit operator Command(CommandBuilder builder) => (Command)builder.Build();
}
