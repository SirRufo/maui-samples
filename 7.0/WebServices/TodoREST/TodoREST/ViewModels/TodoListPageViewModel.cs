using CommunityToolkit.Mvvm.Input;

using TodoREST.Models;
using TodoREST.Services;

namespace TodoREST.ViewModels;

public class TodoListPageViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly ITodoService _todoService;

    public AsyncRelayCommand AddCommand { get; }

    private ICollection<TodoItem> _todoItems;
    private TodoItem _selectedItem;

    public ICollection<TodoItem> TodoItems { get => _todoItems; private set => SetProperty( ref _todoItems, value ); }
    public TodoItem SelectedItem
    {
        get => _selectedItem;
        set => SetProperty( ref _selectedItem, value );
    }

    public TodoListPageViewModel( INavigationService navigationService, ITodoService todoService )
    {
        _navigationService = navigationService;
        _todoService = todoService;

        AddCommand = new AsyncRelayCommand( OnAddAsync );

        this.PropertyChanged += WhenPropertyChanged;
    }

    private async Task OnAddAsync()
    {
        var navigationParameter = new Dictionary<string, object>
            {
                { "TodoItem", new TodoItem { ID = Guid.NewGuid().ToString(), } }
            };
        await _navigationService.GotoAsync( "TodoItem", navigationParameter );
    }

    private async void WhenPropertyChanged( object sender, System.ComponentModel.PropertyChangedEventArgs e )
    {
        if ( e.PropertyName == nameof( SelectedItem ) && SelectedItem is not null )
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "TodoItem", SelectedItem }
            };
            await _navigationService.GotoAsync( "TodoItem", navigationParameter );
        }
    }

    protected override async Task OnInitializeAsync( CancellationToken cancellationToken )
    {
        await base.OnInitializeAsync( cancellationToken );
        TodoItems = await _todoService.GetTasksAsync();
    }
}