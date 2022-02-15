using Ecommerce_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ecommerce_Backend.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DBContext _context;
        internal DbSet<T> _dbSet;
        public readonly ILogger _logger;
        public GenericRepository(DBContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<bool> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetByID(int ID)
        {
            return await _dbSet.FindAsync(ID);
        }

        public virtual bool Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                return true;
            }
            catch (Exception)
            {
                return true;
                throw;
            }
        }
    }
}
