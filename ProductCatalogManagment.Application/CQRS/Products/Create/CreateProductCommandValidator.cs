using FluentValidation;
using ProductCatalogManagment.Application.Interfaces;

namespace ProductCatalogManagment.Application.CQRS.Products.Create
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.ProductInputDto.Name).NotEmpty().WithMessage("نام نمیتواند خالی باشد");
            RuleFor(c => c).MustAsync(CheckLevel).WithMessage("تعداد سطوح نباید بیشتر از 4 سطح باشد");
        }

        private async Task<bool> CheckLevel(CreateProductCommand createProductCommand, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetMaxLevelByParentId(createProductCommand.ProductInputDto.ParentId.Value, cancellationToken);
            if (result> 4)
                return false;
            return true;
        }
    }
}
