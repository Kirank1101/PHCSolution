using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Linq.Expressions;
using System.Data.Entity;

namespace PHC.DataAccess
{

    public class GenericRepository<T> :
    IGenericRepository<T>
        where T : class
    {
        DbContext _entities = null;
        public GenericRepository(IUnitOfWork _entitiesObj)
        {
            this._entities = _entitiesObj as DbContext;
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public IQueryable<T> PagedResult<TResult>(IQueryable<T> query, int pageNum, int pageSize,
            Expression<Func<T, TResult>> OrderByProperty, bool isAscendingOrder, out int rowCount)
        {
            if (pageSize <= 0) pageSize = 20;

            rowCount = query.Count();

            if (rowCount <= pageSize || pageNum <= 0) pageNum = 1;

            int excludedRows = (pageNum - 1) * pageSize;

            query = isAscendingOrder ? query.OrderBy(OrderByProperty) : query.OrderByDescending(OrderByProperty);

            return query.Skip(excludedRows).Take(pageSize);
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add  (entity);
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            //_entities.Attach(entity);
            _entities.Entry(entity).State = System.Data.EntityState.Modified;   
           // _entities.(entity, System.Data.EntityState.Modified);
        }

        public T GetSingleById(Expression<Func<T, bool>> predicateId)
        {
            var query = GetAll().Where(predicateId).FirstOrDefault();
            return query;
        }


        public virtual void Save()
        {
            _entities.SaveChanges();
        }

    }

}
