using MediatR;
using ProductCatalogManagment.Domain.Dtos.Products;

namespace ProductCatalogManagment.Application.CQRS.Products.List
{
    public class GetProductListQuery: IRequest<List<ProductListOutputDto>>
    {

    }
}
