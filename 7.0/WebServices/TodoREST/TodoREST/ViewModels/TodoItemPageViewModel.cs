using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using TodoREST.Models;
using TodoREST.Services;

namespace TodoREST.ViewModels;

[QueryProperty( nameof( TodoItem ), "TodoItem" )]
public partial class TodoItemPageViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly ITodoService _todoService;

    public AsyncRelayCommand SaveCommand { get; }
    public AsyncRelayCommand DeleteCommand { get; }
    public AsyncRelayCommand CancelCommand { get; }

    private TodoItem _todoItem;
    private bool _isNew;

    public TodoItem TodoItem
    {
        get => _todoItem;
        set
        {
            SetProperty( ref _todoItem, value );
            IsNew = IsNewItem( value );
        }
    }

    public bool IsNew { get => _isNew; set => SetProperty( ref _isNew, value ); }

    public TodoItemPageViewModel( INavigationService navigationService, ITodoService todoService )
    {
        _navigationService = navigationService;
        _todoService = todoService;

        SaveCommand = new AsyncRelayCommand( OnSaveAsync );
        DeleteCommand = new AsyncRelayCommand( OnDeleteAsync );
        CancelCommand = new AsyncRelayCommand( OnCancelAsync );
    }

    private async Task OnCancelAsync()
    {
        await _navigationService.GoBackAsync();
    }

    private async Task OnDeleteAsync()
    {
        await _todoService.DeleteTaskAsync( TodoItem );
        await _navigationService.GoBackAsync();
    }

    private async Task OnSaveAsync()
    {
        await _todoService.SaveTaskAsync( TodoItem, IsNew );
        await _navigationService.GoBackAsync();
    }

    bool IsNewItem( TodoItem todoItem )
    {
        if ( string.IsNullOrWhiteSpace( todoItem.Name ) && string.IsNullOrWhiteSpace( todoItem.Notes ) )
            return true;
        return false;
    }

    protected override async Task OnInitializeAsync( CancellationToken cancellationToken )
    {
        await base.OnInitializeAsync( cancellationToken );

    }
}
