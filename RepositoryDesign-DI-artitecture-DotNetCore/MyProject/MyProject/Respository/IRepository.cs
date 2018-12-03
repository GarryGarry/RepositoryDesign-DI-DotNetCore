using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyProject.Respository
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        T Create();

        void Update(T entity);
        void Delete(T entity);

        IQueryable<T> Table { get; }
        IQueryable<T> GetQueryable(bool includeDeleted = false);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

    }
}
