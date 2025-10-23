using MediatR;
using ProductCatalogManagment.Domain.Dtos;

namespace ProductCatalogManagment.Application.CQRS.Create;

public class CreateProductCommand:IRequest<bool>
{
    public ProductInputDto ProductInputDto { get; private set; }

    public CreateProductCommand(ProductInputDto productInputDto)
    {
        ProductInputDto = productInputDto;
    }
}
