using NUnit.Framework;
using Rhino.Mocks;

namespace BasketStateMachine.Unit.Tests
{
    [TestFixture]
    public class Given_nothing
    {
        private IBasket _basket;
        private IBasketRepository _basketRepository;

        [SetUp]
        public void SetUpTest()
        {
            _basketRepository = MockRepository.GenerateStub<IBasketRepository>();
            _basket = new Basket(_basketRepository);
        }

        [Test]
        public void When_Created_then_state_is_initialised_to_Empty()
        {
            Assert.That(_basket.State, Is.EqualTo(BasketState.Empty));
        }
    }
}
