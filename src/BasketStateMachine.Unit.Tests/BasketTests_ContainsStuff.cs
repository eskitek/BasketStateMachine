using NUnit.Framework;

namespace BasketStateMachine.Unit.Tests
{
    [TestFixture]
    public class Given_that_state_is_ContainsStuff
    {
        private IBasket _basket;

        [SetUp]
        public void SetUpTest()
        {
            _basket = new Basket();
        }

        [Test]
        public void And_basket_contains_one_item_when_item_is_removed_from_basket_then_state_is_changed_to_Empty()
        {
            _basket.AddItem();
            _basket.RemoveItem();

            Assert.That(_basket.State, Is.EqualTo(BasketState.Empty));
        }

        [Test]
        public void And_basket_contains_more_than_one_item_when_item_is_removed_from_basket_then_state_does_not_change()
        {
            _basket.AddItem();
            _basket.AddItem();
            _basket.RemoveItem();

            Assert.That(_basket.State, Is.EqualTo(BasketState.ContainsStuff));
        }
    }
}
