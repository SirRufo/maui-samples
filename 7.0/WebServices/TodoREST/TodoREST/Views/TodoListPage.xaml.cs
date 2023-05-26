using TodoREST.ViewModels;

namespace TodoREST.Views;

public partial class TodoListPage : ContentPage
{

    public TodoListPage( TodoListPageViewModel viewModel )
    {
        InitializeComponent();
        BindingContext = viewModel;
        Appearing += async ( s, e ) => await viewModel.InitializeAsync();
    }
}
