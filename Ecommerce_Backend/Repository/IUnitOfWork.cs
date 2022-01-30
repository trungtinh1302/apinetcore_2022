using Ecommerce_Backend.Repository.AccountRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Backend.Repository
{
    public interface IUnitOfWork
    {
        IAccountRepository Account { get; }
        Task CompleteAsync();
    }
}
