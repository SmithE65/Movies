namespace Movies.Core.Data;

public interface ISimpleQuery<TResult, TQuery>
{
    Task<TResult> ExecuteAsync();
}
