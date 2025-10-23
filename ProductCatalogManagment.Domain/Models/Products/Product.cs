namespace ProductCatalogManagment.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public static Product Create(string name, decimal price)
        => new Product(name, price);
    }
}
