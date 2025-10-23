using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogManagment.Application.CQRS.Create;
using ProductCatalogManagment.Domain.Dtos;

namespace ProductCatalogManagment.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("add-product")]
        public async Task<IActionResult> CreateInvoice([FromBody] ProductInputDto productInputDto)
        {
            return Ok(await _mediator.Send(new CreateProductCommand(productInputDto)));
        }
    }
}
