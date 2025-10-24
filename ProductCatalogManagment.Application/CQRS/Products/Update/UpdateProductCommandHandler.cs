using MediatR;
using ProductCatalogManagment.Application.Interfaces;

namespace ProductCatalogManagment.Application.CQRS.Products.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productExist = await _repository.GetById(request.ProductInputDto.Id) ?? throw new Exception("محصول موردنظر وجود ندارد");

            var parent = await _repository.GetByParentIdAsync(request.ProductInputDto.ParentId.Value);

            productExist?.Update(request.ProductInputDto.Name, parent, request.ProductInputDto.Price, request.ProductInputDto.Quantity);

            await _repository.Update(productExist);
            await _repository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}

