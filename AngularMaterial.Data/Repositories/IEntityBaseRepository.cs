using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AngularMaterial.Data.Repositories
{
    public interface IEntityBaseRepository<T> where T : class, new()
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predict);
        T GetSingle(int id);
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
    }
}
