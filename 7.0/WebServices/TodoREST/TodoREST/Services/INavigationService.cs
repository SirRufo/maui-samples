namespace TodoREST.Services;

public interface INavigationService
{
    Task GotoAsync( string route );
    Task GotoAsync( string route, IDictionary<string, object> parameters );
    Task GoBackAsync();
}
