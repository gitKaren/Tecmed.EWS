using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EWS.Domain.Data
{
    public static class EntityExtensions
    {
        #region EagerLoad

        public static IQueryable<TEntity> EagerLoad<TEntity>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, object>> expression)
            where TEntity : DbEntity
        {
            var set = queryable as EntitySet<TEntity>;
            if (set != null)
                set.Queryable = set.Entities.EagerLoad(set.Queryable, expression);
            return queryable;
        }

        public static IQueryable<TEntity> EagerLoad<TEntity>(this IQueryable<TEntity> queryable, IEnumerable<Expression<Func<TEntity, object>>> expressions)
            where TEntity : DbEntity
        {
            if (expressions != null)
                queryable = expressions.Aggregate(queryable, (current, expression) => current.EagerLoad(expression));
            return queryable;
        }

        #endregion

        #region ById (int)

        public static TEntity ById<TEntity>(this IQueryable<TEntity> set, int id, bool allowNull = true) where TEntity : DbEntityWithId<int>
        {
            return allowNull ? set.SingleOrDefault(ById<TEntity>(id)) : set.Single(ById<TEntity>(id));
        }

        public static TEntity ById<TEntity>(this IEnumerable<TEntity> set, int id, bool allowNull = true) where TEntity : DbEntityWithId<int>
        {
            return set.AsQueryable().ById(id, allowNull);
        }

        internal static Expression<Func<TEntity, bool>> ById<TEntity>(int id) where TEntity : DbEntityWithId<int>
        {
            return x => x.Id == id;
        }

        #endregion
    }
}
