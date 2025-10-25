using FluentValidation;

namespace ProductCatalogManagment.Application.CQRS.Products.Update
{
    public class UpdateProductCommandValidator: AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(c => c.ProductInputDto.Name).NotEmpty().WithMessage("نام نمیتواند خالی باشد");
        }
    }
}
