using CQRS_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_DAL.Repository.EF
{
    public interface IProductRepository : IEfRepository<Product>
    {
    }
}
