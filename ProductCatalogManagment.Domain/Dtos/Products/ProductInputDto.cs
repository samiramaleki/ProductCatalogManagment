namespace ProductCatalogManagment.Domain.Dtos.Products
{
    public class ProductInputDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public int? ParentId { get; set; }
    }
}
