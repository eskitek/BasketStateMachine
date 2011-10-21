using NUnit.Framework;
using Rhino.Mocks;

namespace BasketStateMachine.Unit.Tests
{
    [TestFixture]
    public class Given_nothing
    {
        [Test]
        public void When_Created_then_state_is_initialised_to_Empty()
        {
            var basket = new Basket();
            Assert.That(basket.State, Is.EqualTo(BasketState.Empty));
        }
    }
}
