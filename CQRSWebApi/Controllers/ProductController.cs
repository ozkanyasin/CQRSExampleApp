using CQRS_DAL.CQRS.Commands.Request;
using CQRS_DAL.CQRS.Commands.Response;
using CQRS_DAL.CQRS.Queries.Request;
using CQRS_DAL.CQRS.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQueryRequest requestModel)
        {
            List<GetAllProductQueryResponse> allProducts = await _mediator.Send(requestModel);
            return Ok(allProducts);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> Get([FromQuery] GetProductByIdQueryRequest requestModel)
        {
            GetProductByIdQueryResponse product = await _mediator.Send(requestModel);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommandRequest requestModel)
        {
            CreateProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] DeleteProductCommandRequest requestModel)
        {
            DeleteProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }

    }
}
