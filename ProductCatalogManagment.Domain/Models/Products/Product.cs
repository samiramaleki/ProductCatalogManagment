namespace ProductCatalogManagment.Domain
{
    public class Product
    {
        public const int MaxLevel = 4;

        public Product()
        {

        }

        public int Id { get; set; }
        public string Name { get; private set; } = string.Empty;
        public int Level { get; private set; }
        public int? ParentId { get; private set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }

        public Product? Parent { get; private set; }
        public ICollection<Product> Children { get; set; } = new List<Product>();

        private Product(string name, Product? parent, decimal? price, int? quantity)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("نام نمیتواند خالی باشد");
            Name = name;
            Price = price;
            Quantity = quantity;
            Parent = parent;
        }

        public static Product Create(string name, Product? parent, decimal? price, int? quantity)
        => new Product(name, parent, price, quantity);

        public void Update(string name, Product? parent, decimal? price, int? quantity)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("نام نمیتواند خالی باشد");
            Name = name;
            Parent = parent;
            Price = price;
            Quantity = quantity;
        }

        public void SetLevel(int? level)
        {
            if (level >= MaxLevel)
                throw new Exception("بیشتر از 4  سطح نمی توان ایجاد کرد");

            if (level.HasValue)
                Level = level.Value + 1;
            else Level = 1;
        }

        public void HasChildren()
        {
            if (Children.Any())
                throw new Exception("امکان حذف سطوح دارای زیر مجموعه وجود ندارد");
        }
    }
}
