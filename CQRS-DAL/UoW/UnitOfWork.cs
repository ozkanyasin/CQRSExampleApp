using CQRS_DAL.Context;
using CQRS_DAL.Repository.Dapper;
using CQRS_DAL.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CQRSContext _context;
        private IProductRepository _productRepository;
        private IDapperProductRepository _dapperProductRepository;
        IProductRepository IUnitOfWork.ProductRepository => _productRepository ??= new ProductRepository(_context);
        IDapperProductRepository IUnitOfWork.DapperProductRepository => _dapperProductRepository ?? new DapperProductRepository();

        public UnitOfWork(CQRSContext context)
        {
            this._context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();

        }
    }
}
