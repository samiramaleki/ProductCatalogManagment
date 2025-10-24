using MediatR;
using ProductCatalogManagment.Domain.Dtos.Products;

namespace ProductCatalogManagment.Application.CQRS.Products.Update
{
    public class UpdateProductCommand:IRequest<bool>
    {
        public ProductInputDto ProductInputDto { get; private set; }

        public UpdateProductCommand(ProductInputDto productInputDto)
        {
            ProductInputDto = productInputDto;
        }
    }
}
