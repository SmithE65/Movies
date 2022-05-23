namespace Movies.Core.Data;

public interface IQuery<TResult, TQuery>
{
    Task<TResult> ExecuteAsync(TQuery query);
}
