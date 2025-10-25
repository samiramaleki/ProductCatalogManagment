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

        public ProductFixture()
        {
            FillMock();
        }

        public void FillMock()
        {
            Name = "تیشرت";
            ParentId = 1;
            Price = 21232;
            Quantity = 10;

        }
    }
}
