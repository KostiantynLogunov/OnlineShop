using AutoFixture;
using OnlineShop.Library.Clients.GoodsService;
using OnlineShop.Library.GoodsService.Models;
using OnlineShop.Library.Options;


namespace OnlineShop.GoodsService.ApiTests
{
    public class PriceListsRepoClientTests : GoodsServiceRepoBaseApiTest<PriceListsClient, PriceList>
    {
        private GoodsClient GoodsClient;
        private Guid _articleId;

        [Test]
        public async override Task GIVEN_Repo_Client_WHEN_I_add_entity_THEN_it_is_being_added_to_database()
        {
            var goods = Fixture.Build<Goods>().Create();

            var addGoodsResponse = await GoodsClient.Add(goods);
            Assert.IsTrue(addGoodsResponse.IsSuccessfull);
            _articleId = goods.Id;

            await base.GIVEN_Repo_Client_WHEN_I_add_entity_THEN_it_is_being_added_to_database();

            var removeGoodsResponse = await GoodsClient.Remove(goods.Id);
            Assert.IsTrue(removeGoodsResponse.IsSuccessfull);
        }

        [Test]
        public async override Task GIVEN_Repo_Client_WHEN_I_add_several_entities_THEN_it_is_being_added_to_database()
        {
            var goods = Fixture.Build<Goods>().Create();

            var addArticleResponse = await GoodsClient.Add(goods);
            Assert.IsTrue(addArticleResponse.IsSuccessfull);
            _articleId = goods.Id;

            await base.GIVEN_Repo_Client_WHEN_I_add_several_entities_THEN_it_is_being_added_to_database();

            var removeArticleResponse = await GoodsClient.Remove(goods.Id);
            Assert.IsTrue(removeArticleResponse.IsSuccessfull);
        }

        [Test]
        public async override Task GIVEN_Repo_Client_WHEN_I_update_entuty_THEN_it_is_being_updated_in_database()
        {
            var goods = Fixture.Build<Goods>().Create();

            var addArticleResponse = await GoodsClient.Add(goods);
            Assert.IsTrue(addArticleResponse.IsSuccessfull);
            _articleId = goods.Id;

            await base.GIVEN_Repo_Client_WHEN_I_update_entuty_THEN_it_is_being_updated_in_database();

            var removeArticleResponse = await GoodsClient.Remove(goods.Id);
            Assert.IsTrue(removeArticleResponse.IsSuccessfull);
        }

        protected override void CreateSystemUnderTests()
        {
            SystemUnderTests = new PriceListsClient(new HttpClient(), ServiceAdressOptions);
            GoodsClient = new GoodsClient(new HttpClient(), ServiceAdressOptions);
        }

        protected override async Task AuthorizeSystemUnderTests()
        {
            /*var token = await LoginClient.GetApiTokenByClientSeceret(IdentityServerApiOptions);
            SystemUnderTests.HttpClient.SetBearerToken(token.AccessToken);
            GoodsClient.HttpClient.SetBearerToken(token.AccessToken);*/
        }

        protected override void AssertObjectsAreEqual(PriceList expected, PriceList actual)
        {
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Price, actual.Price);
            Assert.AreEqual(expected.ValidFrom, actual.ValidFrom);
            Assert.AreEqual(expected.ValidTo, actual.ValidTo);
        }

        protected override void AmendExpectedEntityForUpdating(PriceList expected)
        {
            expected.Name = Fixture.Create<string>();
            expected.Price = Fixture.Create<decimal>();
            expected.ValidFrom = Fixture.Create<DateTime>();
            expected.ValidTo = Fixture.Create<DateTime>();
        }

        protected override PriceList CreateExpectedEntity() => Fixture.Build<PriceList>().With(e => e.GoodsId, _articleId).Create();
    }
}
