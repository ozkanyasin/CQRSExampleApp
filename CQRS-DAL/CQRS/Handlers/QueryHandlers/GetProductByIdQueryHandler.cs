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
        private readonly IDapperProductRepository _productRepository;
        private readonly IUnitOfWork _uow;

        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var item = await _uow.DapperProductRepository.GetAllAsync();
            var result = new List<GetAllProductQueryResponse>();
            

            return null;
        }
    }
}
