using Ecommerce_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Backend.Repository.AccountRepositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(DBContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Account>> GetAll()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                throw ex;
            }
        }

        public override async Task<bool> Update(Account entity)
        {
            try
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    var existingAccount = await _dbSet.Where(x => x.ID == entity.ID)
                                                    .FirstOrDefaultAsync();

                    if (existingAccount != null)
                    {
                        return await Update(entity);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Account error error");
                return false;
            }
        }

        public override async Task<bool> Delete(int ID)
        {
            try
            {
                var exist = await _dbSet.Where(x => x.ID == ID)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                _dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete error");
                return false;
            }
        }

        public async Task<int> CreateAccount(Account entity)
        {
            // 0: success, 1: exist, 2: error
            if (!string.IsNullOrEmpty(entity.Username))
            {
                entity.CreatedTime = DateTime.Now;
                entity.Status = false;
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        await _dbSet.AddAsync(entity);
                        await transaction.CommitAsync();
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                        transaction.Rollback();
                    }
                }
            }
            else
            {
                return 1;
            }
        }
    }
}