
namespace EWS.Domain.Data
{
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQueryDefinition<TResult>
    {
        TResult Handle(TQuery query);
    }
}