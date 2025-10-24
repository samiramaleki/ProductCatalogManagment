using MediatR;
using ProductCatalogManagment.Application.Interfaces;

namespace ProductCatalogManagment.Application.CQRS.Products.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(request.Id) ?? throw new Exception("آیتم مورد نظر یافت نشد");
            product.HasChildren();

            await _repository.Delete(product);
            await _repository.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
