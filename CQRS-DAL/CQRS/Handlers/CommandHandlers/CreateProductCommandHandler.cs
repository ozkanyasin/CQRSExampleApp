using CQRS_DAL.CQRS.Commands.Request;
using CQRS_DAL.CQRS.Commands.Response;
using CQRS_DAL.Entities;
using CQRS_DAL.Repository.EF;
using CQRS_DAL.UoW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_DAL.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateProductCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = new Product()
            {
                Name = request.Name,
                CreateTime = DateTime.Now,
                Price = request.Price,
                Quantity = request.Quantity
            };

            await _uow.ProductRepository.AddAsync(entity);
            await _uow.CommitAsync();

            var result = new CreateProductCommandResponse()
            {
                IsSuccess = true,
                ProductId = entity.Id
            };

            return result;
        }
    }
}
