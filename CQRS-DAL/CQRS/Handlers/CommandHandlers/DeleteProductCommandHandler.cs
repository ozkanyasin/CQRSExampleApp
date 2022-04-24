using CQRS_DAL.CQRS.Commands.Request;
using CQRS_DAL.CQRS.Commands.Response;
using CQRS_DAL.Entities;
using CQRS_DAL.UoW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_DAL.CQRS.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IUnitOfWork _uow;

        public DeleteProductCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _uow.ProductRepository.GetByIdAsync(request.Id);
            

            _uow.ProductRepository.Remove(deletedEntity);
            await _uow.CommitAsync();

            var result = new DeleteProductCommandResponse()
            {
                IsSuccess = true
            };

            return result;
        }
    }
}
