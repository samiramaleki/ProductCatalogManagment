using MediatR;

namespace ProductCatalogManagment.Application.CQRS.Products.Delete
{
    public class DeleteProductCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
