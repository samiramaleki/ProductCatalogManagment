namespace ProductCatalogManagment.Domain.Dtos.Products
{
    public class ProductListOutputDto
    {
        public long Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public int Level { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public List<ProductListOutputDto> Children { get; set; } = new();
    }
}
