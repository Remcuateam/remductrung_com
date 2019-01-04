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
    public class EFRepository_GuidId<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>, IDisposable where TEntity : DomainEntity<TPrimaryKey>
    {
        protected readonly AppDbContext _context;
        private bool disposed = false;
        public EFRepository(AppDbContext context)
        {
            _context = context;
        }

        public TEntity Update(TEntity entity)
        {
            var result = _context.Set<TEntity>().Update(entity);
            return result.Entity;
        }

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
            /// CountAsync
            /// using Microsoft.EntityFrameworkCore;
            return await GetAll().CountAsync(predicate);
        }

        public async Task<int> CountAsync()
        {
            return await GetAll().CountAsync();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Delete(TPrimaryKey id)
        {
            _context.Set<TEntity>().Remove(GetById(id));
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            _context.Set<TEntity>().RemoveRange(GetAll().Where(predicate));
        }

     

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

        public TEntity GetById(TPrimaryKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll(bool isAll = true)
        {
            if(typeof(TEntity) is ISoftDelete && isAll ==false)
            {
                return _context.Set<TEntity>().Where(x => ((ISoftDelete)x).IsDeleted == false).AsQueryable();
            }
            return _context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, bool isAll = true)
        {
            return GetAll(isAll).Where(predicate);
        }

        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            IQueryable<TEntity> items = GetAll();

            if (propertySelectors != null)
            {
                foreach (var includeProperty in propertySelectors)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
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

        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

      
        public TEntity Insert(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity).Entity;
        }

       

        public long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().LongCount(predicate);
        }

        public long LongCount()
        {
            return GetAll().LongCount();
        }

        public async Task<long> LongCountAsync()
        {
            return await GetAll().LongCountAsync();
        }

        public async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().LongCountAsync(predicate);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Single(predicate);
        }

        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().SingleAsync(predicate);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
