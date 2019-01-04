using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.EF
{
    /// <summary>
    /// Serves as a generic base class for concrete repositories to support basic CRUD operations on data in the system
    /// </summary>
    /// <typeparam name="TEntity">The type of entity this repository work with. Must be a class inheriting DomainEntity</typeparam>
    /// <typeparam name="TPrimaryKey">The type of Primary Key</typeparam>
    public class EFRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>, IDisposable where TEntity : DomainEntity<TPrimaryKey>
    {
        private readonly AppDbContext _context;

        public EFRepository(AppDbContext context)
        {
            _context = context;
        }

        #region GetById

        public TEntity GetById(TPrimaryKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public TEntity GetById(TPrimaryKey id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetAll(includeProperties).SingleOrDefault(x => x.Id.Equals(id));
        }
        public async Task<TEntity> GetByIdAsync(TPrimaryKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Single(predicate);
        }
      
        public TEntity Single(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetAll(includeProperties).SingleOrDefault(predicate);
        }

        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().SingleAsync(predicate);
        }
        #endregion


        #region GetAll
        public IQueryable<TEntity> GetAll(bool isAll = true)
        {
            if (typeof(TEntity) is ISoftDelete && isAll == false)
            {
                return _context.Set<TEntity>().Where(x => ((ISoftDelete)x).IsDeleted == false).AsQueryable();
            }
            return _context.Set<TEntity>().AsQueryable();
        }
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, bool isAll = true)
        {
            return GetAll(isAll).Where(predicate);
        }
        
        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> items = _context.Set<TEntity>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> items = _context.Set<TEntity>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(predicate);
        }
        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        public List<TEntity> GetAllList()
        {
            return GetAll().ToList();
        }
        public async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllListAsync()
        {
            return await GetAll().ToListAsync();
        }
        #endregion


        #region CRUD
        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public void Remove(TPrimaryKey id)
        {
            var entity = GetById(id);
            Remove(entity);
        }
        public void Remove(Expression<Func<TEntity, bool>> predicate)
        {
            _context.Set<TEntity>().RemoveRange(GetAll().Where(predicate));
        }
        public void RemoveMultiple(List<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
        #endregion


        #region Count  
        public int Count()
        {
            return GetAll().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Count(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().CountAsync(predicate);
        }

        public async Task<int> CountAsync()
        {
            return await GetAll().CountAsync();
        }

        public long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().LongCount(predicate);
        }
        #endregion

        #region FirstOrDefault
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        public TEntity FirstOrDefault(TPrimaryKey id)
        {
            return _context.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(id));
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
        #endregion



        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

       

       
    }
}
