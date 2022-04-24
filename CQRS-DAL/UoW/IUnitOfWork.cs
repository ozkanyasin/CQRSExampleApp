using CQRS_DAL.Repository.Dapper;
using CQRS_DAL.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_DAL.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();

        IProductRepository ProductRepository { get; }
        IDapperProductRepository DapperProductRepository { get; }
    }
}
