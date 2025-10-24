using MediatR;
using ProductCatalogManagment.Domain.Dtos.Products;

namespace ProductCatalogManagment.Application.CQRS.Products.Create;

public class CreateProductCommand : IRequest<bool>
{
    public ProductInputDto ProductInputDto { get; private set; }

    public CreateProductCommand(ProductInputDto productInputDto)
    {
        ProductInputDto = productInputDto;
    }
}
