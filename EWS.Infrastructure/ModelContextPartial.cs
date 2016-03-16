using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data;

namespace EWS.Infrastructure
{
    public partial class Entities : DbContext, IEntityWriter
    {
        #region Queries

        public IQueryable<TEntity> EagerLoad<TEntity>(IQueryable<TEntity> query,
            Expression<Func<TEntity, object>> expression) where TEntity : DbEntity
        {
            if (query != null && expression != null) query = query.Include(expression);
            return query;
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : DbEntity
        {
            return new EntitySet<TEntity>(Set<TEntity>(), this);
        }

        #endregion

        #region Commands

        public TEntity Get<TEntity>(object firstKeyValue, params object[] otherKeyValues) where TEntity : DbEntity
        {
            if (firstKeyValue == null) throw new ArgumentNullException("firstKeyValue");
            var keyValues = new List<object> { firstKeyValue };
            if (otherKeyValues != null) keyValues.AddRange(otherKeyValues);
            return Set<TEntity>().Find(keyValues.ToArray());
        }

        public IQueryable<TEntity> Get<TEntity>() where TEntity : DbEntity
        {
            return new EntitySet<TEntity>(Set<TEntity>(), this);
        }

        public void Create<TEntity>(TEntity entity) where TEntity : DbEntity
        {
            if (Entry(entity).State == EntityState.Detached) Set<TEntity>().Add(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : DbEntity
        {
            var entry = Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : DbEntity
        {
            if (Entry(entity).State != EntityState.Deleted)
                Set<TEntity>().Remove(entity);
        }

        public void Reload<TEntity>(TEntity entity) where TEntity : DbEntity
        {
            Entry(entity).Reload();
        }

        #endregion

        #region UnitOfWork

        public void DiscardChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(x => x != null))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

        #endregion

        #region Audit/SoftDelete

        public override int SaveChanges()
        {
            //Do soft deletes
            foreach (var deletableEntity in ChangeTracker.Entries<ISoftDeleteEntity>())
            {
                if (deletableEntity.State == EntityState.Deleted)
                {
                    //Deleted - set the deleted flag
                    deletableEntity.State = EntityState.Unchanged; //We need to set this to unchanged here, because setting it to modified seems to set ALL of its fields to modified
                    deletableEntity.Entity.Deleted = true; //This will set the entity's state to modified for the next time we query the ChangeTracker
                }
            }

            return base.SaveChanges();
        }

        #endregion


    }
}
