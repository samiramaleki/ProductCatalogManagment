namespace ProductCatalogManagment.Domain.UnitTest
{
    public class ProductTests : IClassFixture<ProductFixture>
    {
        private readonly ProductFixture _fixture;

        public ProductTests(ProductFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Create_Product_Should_Have_Error_When_Name_Is_Empty()
        {
            var expectation = "نام نمیتواند خالی باشد";

            var result = Assert.Throws<Exception>(() =>
                Product.Create("", null, _fixture.Price, _fixture.Quantity));

            Assert.Equal(result.Message, expectation);
        }


        [Fact]
        public void Update_Product_Should_Have_Error_When_Name_Is_Empty()
        {
            var expectation = "نام نمیتواند خالی باشد";

            var result = Assert.Throws<Exception>(() =>
                Product.Create("", null, _fixture.Price, _fixture.Quantity));

            Assert.Equal(result.Message, expectation);
        }

        [Fact]
        public void Create_Product_Level_Should_Not_Exceed_Max()
        {
            var expectation = "بیشتر از 4  سطح نمی توان ایجاد کرد";

            var result = Assert.Throws<Exception>(() =>
                _fixture.Product.SetLevel(_fixture.Product.Level));

            Assert.Equal(result.Message, expectation);
        }
    }
}
