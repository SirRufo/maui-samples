using CommunityToolkit.Mvvm.ComponentModel;

namespace TodoREST.ViewModels;

public abstract partial class ViewModelBase : ObservableObject
{
    private bool _isInitialized;
    public bool IsInitialized { get => _isInitialized; private set => SetProperty( ref _isInitialized, value ); }

    public async Task InitializeAsync( CancellationToken cancellationToken = default )
    {
        await OnInitializeAsync( cancellationToken );
        IsInitialized = true;
    }

    protected virtual Task OnInitializeAsync( CancellationToken cancellationToken )
        => Task.CompletedTask;
}
