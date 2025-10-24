using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogManagment.Application.CQRS.Products.Create;
using ProductCatalogManagment.Application.CQRS.Products.Delete;
using ProductCatalogManagment.Application.CQRS.Products.List;
using ProductCatalogManagment.Application.CQRS.Products.Update;
using ProductCatalogManagment.Domain.Dtos.Products;

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

        [HttpGet]
        [Route("products")]
        public async Task<ActionResult<List<ProductListOutputDto>>> Invoices()
        {
            return Ok(await _mediator.Send(new GetProductListQuery { }));
        }

        [Route("delete-{id}-product")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await _mediator.Send(new DeleteProductCommand { Id = id }));
        }

        [HttpPut]
        [Route("update-product")]
        public async Task<IActionResult> UpdateDependentCreditNote([FromBody] ProductInputDto  productInputDto)
        {
            return Ok(await _mediator.Send(new UpdateProductCommand(productInputDto)));
        }
    }
}
