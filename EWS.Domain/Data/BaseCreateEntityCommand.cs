
namespace EWS.Domain.Data
{
    public abstract class BaseCreateEntityCommand<TEntity> : BaseEntityCommand where TEntity : DbEntity
    {
        public TEntity CreatedEntity { get; set; }
    }
}