using TodoREST.ViewModels;

namespace TodoREST.Views;

public partial class TodoItemPage : ContentPage
{
    public TodoItemPage( TodoItemPageViewModel viewModel )
    {
        InitializeComponent();
        BindingContext = viewModel;
        Appearing += async ( s, e ) => await viewModel.InitializeAsync();
    }
}
