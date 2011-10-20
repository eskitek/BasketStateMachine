using NUnit.Framework;

namespace BasketStateMachine.Unit.Tests
{
    [TestFixture]
    public class Given_that_state_is_Empty
    {
        private IBasket _basket;

        [SetUp]
        public void SetUpTest()
        {
            _basket = new Basket();
        }

        [Test]
        public void Given_that_a_basket_has_just_been_created_then_state_is_Empty()
        {
            Assert.That(_basket.State, Is.EqualTo(BasketState.Empty));
        }

        [Test]
        public void When_item_is_added_to_basket_then_state_is_changed_to_ContainsStuff()
        {
            _basket.AddItem();

            Assert.That(_basket.State, Is.EqualTo(BasketState.ContainsStuff));
        }

        [Test]
        public void When_item_is_removed_from_basket_then_state_remains_Empty()
        {
            _basket.RemoveItem();

            Assert.That(_basket.State, Is.EqualTo(BasketState.Empty));
        }

        [Test]
        public void When_checkout_is_called_then_state_remains_Empty()
        {
            _basket.Checkout();

            Assert.That(_basket.State, Is.EqualTo(BasketState.Empty));
        }

        [Test]
        public void When_archive_is_called_then_state_changes_to_Archived()
        {
            _basket.Archive();

            Assert.That(_basket.State, Is.EqualTo(BasketState.Archived));
        }
    }
}
