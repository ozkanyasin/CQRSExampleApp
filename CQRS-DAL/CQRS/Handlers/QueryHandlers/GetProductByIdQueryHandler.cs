using CQRS_DAL.CQRS.Queries.Request;
using CQRS_DAL.CQRS.Queries.Response;
using CQRS_DAL.Repository.Dapper;
using CQRS_DAL.UoW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_DAL.CQRS.Handlers.QueryHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var item = await _uow.DapperProductRepository.GetByIdAsync(request.Id);
            
            var result = new GetProductByIdQueryResponse()
            {
                Id = item.Id,
                CreateTime = DateTime.Now,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            };

            return result;
        }
    }
}
