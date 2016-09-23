using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Linq.Expressions;

namespace PHC.DataAccess
{

    public class GenericRepository<T> :
    IGenericRepository<T>
        where T : class
    {
        ObjectContext _entities = null;
        public GenericRepository(IUnitOfWork _entitiesObj)
        {
            this._entities = _entitiesObj as ObjectContext;
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = _entities.CreateObjectSet<T>();
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
            IQueryable<T> query = _entities.CreateObjectSet<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _entities.CreateObjectSet<T>().AddObject(entity);
        }

        public virtual void Delete(T entity)
        {
            _entities.CreateObjectSet<T>().DeleteObject(entity);
        }

        public virtual void Edit(T entity)
        {
            //_entities.Attach(entity);
            _entities.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
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
