using MediatR;
using ProductCatalogManagment.Application.Interfaces;
using ProductCatalogManagment.Domain;

namespace ProductCatalogManagment.Application.CQRS.Create
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
            var product = Product.Create(request.ProductInputDto.Name, request.ProductInputDto.Price);
            await _repository.Create(product);
            await _repository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
