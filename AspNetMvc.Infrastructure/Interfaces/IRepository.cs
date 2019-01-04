using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AspNetMvc.Infrastructure.SharedKernel;
using AspNetMvc.Infrastructure.Enums;


namespace AspNetMvc.Infrastructure.Interfaces
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : DomainEntity<TPrimaryKey>
    {

        #region GetById
        TEntity GetById(TPrimaryKey id);

        TEntity GetById(TPrimaryKey id, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity> GetByIdAsync(TPrimaryKey id);
    
        TEntity Single(Expression<Func<TEntity, bool>> predicate);

        TEntity Single(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

        
        #endregion

        #region GetAll
        IQueryable<TEntity> GetAll(bool isAll = true);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, bool IsAll = true);
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAllList();

        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate); //     Used to get all entities based on given predicate.

        Task<List<TEntity>> GetAllListAsync();  //     Used to get all entities.
        #endregion

        #region CRUD
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void Remove(TPrimaryKey id);
      
        void Remove(Expression<Func<TEntity, bool>> predicate); // Deletes many entities by function.Notice that: All entities fits to given predicate
                                                                //     are retrieved and deleted. 
        void RemoveMultiple(List<TEntity> entities);
        #endregion

        #region Count       
        int Count(); //  Gets count of all entities in this repository.

        int Count(Expression<Func<TEntity, bool>> predicate); //     Gets count of all entities in this repository based on given predicate.

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate); // Gets count of all entities in this repository based on given predicate.

        Task<int> CountAsync();  //     Gets count of all entities in this repository.

        long LongCount(Expression<Func<TEntity, bool>> Predicate);  //     Gets count of all entities in this repository based on given predicate (use this
                                                                    //     overload if expected return value is greather than System.Int32.MaxValue).
        #endregion

        #region FirstOrDefault
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);  //     Gets an entity with given given predicate or null if not found.

        TEntity FirstOrDefault(TPrimaryKey id);  //     Gets an entity with given primary key or null if not found.

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);   //     Gets an entity with given given predicate or null if not found.

        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);  //     Gets an entity with given primary key or null if not found.
        #endregion

    }
}
