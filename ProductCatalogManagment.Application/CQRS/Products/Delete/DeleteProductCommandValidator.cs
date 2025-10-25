using FluentValidation;
using ProductCatalogManagment.Application.Interfaces;

namespace ProductCatalogManagment.Application.CQRS.Products.Delete
{
    public class DeleteProductCommandValidator: AbstractValidator<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(c => c).MustAsync(HasChildern).WithMessage("امکان حذف سطوح دارای زیر مجموعه وجود ندارد");
        }

        private async Task<bool> HasChildern(DeleteProductCommand  deleteProductCommand, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetByParentIdAsync(deleteProductCommand.Id, cancellationToken);
            if (result.Children.Count > 0)
                return false;
            return true;
        }
    }
}
