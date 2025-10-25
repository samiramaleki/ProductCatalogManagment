using MediatR;
using ProductCatalogManagment.Application.Interfaces;
using ProductCatalogManagment.Domain;

namespace ProductCatalogManagment.Application.CQRS.Products.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var parent = await _repository.GetByParentIdAsync(request.ProductInputDto.ParentId.Value)?? throw new Exception("شناسه ParentId موردنظر وجود ندارد");

            var maxLevel = await _repository.GetMaxLevelByParentId(request.ProductInputDto.ParentId.Value, cancellationToken);

            var category = Product.Create(request.ProductInputDto.Name, parent, request.ProductInputDto.Price, request.ProductInputDto.Quantity);
            category.SetLevel(maxLevel);

            await _repository.Create(category);
            await _repository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
