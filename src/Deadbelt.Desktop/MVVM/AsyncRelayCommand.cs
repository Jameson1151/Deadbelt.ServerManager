using System.Windows.Input;

namespace Deadbelt.Desktop.MVVM;

public sealed class AsyncRelayCommand : ICommand
{
    private readonly Func<object?, Task> _executeAsync;
    private readonly Predicate<object?>? _canExecute;
    private bool _isExecuting;

    public AsyncRelayCommand(Func<Task> executeAsync)
        : this(_ => executeAsync(), null)
    {
    }

    public AsyncRelayCommand(Func<Task> executeAsync, Func<bool> canExecute)
        : this(_ => executeAsync(), _ => canExecute())
    {
    }

    public AsyncRelayCommand(Func<object?, Task> executeAsync)
        : this(executeAsync, null)
    {
    }

    public AsyncRelayCommand(Func<object?, Task> executeAsync, Predicate<object?>? canExecute)
    {
        _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return !_isExecuting && (_canExecute?.Invoke(parameter) ?? true);
    }

    public async void Execute(object? parameter)
    {
        await ExecuteAsync(parameter);
    }

    public async Task ExecuteAsync(object? parameter = null)
    {
        if (!CanExecute(parameter))
            return;

        try
        {
            _isExecuting = true;
            RaiseCanExecuteChanged();

            await _executeAsync(parameter);
        }
        finally
        {
            _isExecuting = false;
            RaiseCanExecuteChanged();
        }
    }

    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}