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
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var list = await _uow.DapperProductRepository.GetAllAsync();
            var result = new List<GetAllProductQueryResponse>();
            foreach (var item in list)
            {
                result.Add(new GetAllProductQueryResponse()
                {
                    Id = item.Id,
                    CreateTime = item.CreateTime,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity
                });
            };

            return result;
        }
    }
}
