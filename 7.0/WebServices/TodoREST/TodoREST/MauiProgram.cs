using TodoREST.Services;
using TodoREST.ViewModels;
using TodoREST.Views;

namespace TodoREST;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts( fonts =>
            {
                fonts.AddFont( "OpenSans-Regular.ttf", "OpenSansRegular" );
                fonts.AddFont( "OpenSans-Semibold.ttf", "OpenSansSemibold" );
            } );

        builder.Services.AddSingleton<IHttpsClientHandlerService, HttpsClientHandlerService>();
        builder.Services.AddSingleton<IRestService, RestService>();
        builder.Services.AddSingleton<ITodoService, TodoService>();
        builder.Services.AddSingleton<INavigationService, MauiNavigationService>();

        builder.Services.AddSingleton<AppShell>();

        builder.Services.AddSingleton<TodoListPage>().AddSingleton<TodoListPageViewModel>();
        builder.Services.AddSingleton<TodoItemPage>().AddSingleton<TodoItemPageViewModel>();

        return builder.Build();
    }
}
