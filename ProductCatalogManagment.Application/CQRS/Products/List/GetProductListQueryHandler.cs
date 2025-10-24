using MediatR;
using ProductCatalogManagment.Application.Interfaces;
using ProductCatalogManagment.Domain.Dtos.Products;

namespace ProductCatalogManagment.Application.CQRS.Products.List
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductListOutputDto>>
    {
        private readonly IProductRepository _repository;

        public GetProductListQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductListOutputDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProductListsAsync(cancellationToken);
        }
    }
}
