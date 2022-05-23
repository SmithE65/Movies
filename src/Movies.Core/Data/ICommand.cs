namespace Movies.Core.Data;

public interface ICommand<T>
{
    Task ExecuteAsync(T query);
}