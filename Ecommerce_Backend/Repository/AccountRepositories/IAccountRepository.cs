using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Backend.Repository.AccountRepositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<int> CreateAccount(Account entity);
    }
}
