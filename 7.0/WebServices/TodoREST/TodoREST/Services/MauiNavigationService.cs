namespace TodoREST.Services;

public class MauiNavigationService : INavigationService
{
    public Task GoBackAsync()
        => Shell.Current.GoToAsync( ".." );

    public Task GotoAsync( string route )
        => Shell.Current.GoToAsync( route );

    public Task GotoAsync( string route, IDictionary<string, object> parameters )
        => Shell.Current.GoToAsync( route, parameters );
}