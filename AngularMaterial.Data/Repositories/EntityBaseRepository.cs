using AngularMaterial.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AngularMaterial.Data.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private AngularMaterialContext dbContext;

        protected AngularMaterialContext DbContext
        {
            get
            {
                return dbContext ?? (dbContext = new AngularMaterialContext());
            }
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predict)
        {
            return DbContext.Set<T>().Where(predict);
        }
        public virtual T GetSingle(int id)
        {
            return GetAll().SingleOrDefault(t => t.ID == id);
        }
        public virtual void Add(T entity)
        {
            DbEntityEntry entry = DbContext.Entry<T>(entity);
            entry.State = EntityState.Added;
            DbContext.SaveChanges();
        }
        public virtual void Edit(T entity)
        {
            DbEntityEntry entry = DbContext.Entry<T>(entity);
            entry.State = EntityState.Modified;
            DbContext.SaveChanges();
        }
        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = DbContext.Entry<T>(entity);
            entry.State = EntityState.Deleted;
            DbContext.SaveChanges();
        }
    }
}
