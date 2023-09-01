using AutoFixture;
using OnlineShop.Library.Clients.GoodsService;
using OnlineShop.Library.GoodsService.Models;

namespace OnlineShop.GoodsService.ApiTests
{
     public class GoodsRepoClientTests : GoodsServiceRepoBaseApiTest<GoodsClient, Goods>
    {
        protected override void CreateSystemUnderTests()
        {
            SystemUnderTests = new GoodsClient(new HttpClient(), ServiceAdressOptions);
        }

        protected override void AssertObjectsAreEqual(Goods expected, Goods actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Description, actual.Description);
        }

        protected override void AmendExpectedEntityForUpdating(Goods expected)
        {
            expected.Name = Fixture.Create<string>();
            expected.Description = Fixture.Create<string>();
        }
    }
}
