using CQRS_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_DAL.Repository.Dapper
{
    public interface IDapperProductRepository
    {
        ValueTask<Product> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();
        
    }
}
