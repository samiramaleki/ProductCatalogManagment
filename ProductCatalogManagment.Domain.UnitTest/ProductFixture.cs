using System.Net.NetworkInformation;
using Xunit;

namespace ProductCatalogManagment.Domain.UnitTest
{
    public class ProductFixture
    {
        public string Name { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public Product? Parent { get; set; }
        public Product Product { get; set; }

        public ProductFixture()
        {
            FillMock();
        }

        public void FillMock()
        {
            var productList = GetProductsForLevelTest();
            Product = productList.Last();
            Name = "تیشرت لارج";
            ParentId = 1;
            Price = 21232;
            Quantity = 10;
        }

        public static List<Product> GetProductsForLevelTest()
        {
            var products = new List<Product>();

            // سطح 1 - ریشه
            var root = Product.Create("پوشاک", null, 0, 0);
            root.SetLevel(null);

            // سطح 2
            var men = Product.Create("مردانه", root, 0, 0);
            men.SetLevel(root.Level);

            var women = Product.Create("زنانه", root, 0, 0);
            women.SetLevel(root.Level);

            root.Children.Add(men);
            root.Children.Add(women);

            // سطح 3
            var tshirt = Product.Create("تی‌شرت", men, 0, 0);
            tshirt.SetLevel(men.Level);

            var pants = Product.Create("شلوار", women, 0, 0);
            pants.SetLevel(women.Level);

            men.Children.Add(tshirt);
            women.Children.Add(pants);

            // سطح 4
            var tshirtShort = Product.Create("تی‌شرت مردانه آستین کوتاه", tshirt, 0, 0);
            tshirtShort.SetLevel(tshirt.Level);

            var jeans = Product.Create("شلوار زنانه جین آبی", pants, 0, 0);
            jeans.SetLevel(pants.Level);

            tshirt.Children.Add(tshirtShort);
            pants.Children.Add(jeans);

            products.AddRange(new[]
            {
             root, men, women, tshirt, pants, tshirtShort, jeans
            });

            return products;
        }

    }
}
