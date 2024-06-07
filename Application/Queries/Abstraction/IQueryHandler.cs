namespace Application.Queries.Abstraction;

/// <summary>
/// Query handler interface
/// </summary>
/// <typeparam name="TQuery">Query instance <see cref="IQuery{TResult}"/></typeparam>
/// <typeparam name="TResult">Result type</typeparam>
public interface IQueryHandler<in TQuery, TResult> where TQuery : class, IQuery<TResult>
{
    Task<TResult> HandleAsync(TQuery query);
}