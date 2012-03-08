using System;
using BasketStateMachine.BasketStates;
using NUnit.Framework;

namespace BasketStateMachine.Unit.Tests
{
    [TestFixture]
    public class Given_that_state_is_Empty
    {
        private Basket _basket;

        [SetUp]
        public void SetUpTest()
        {
            _basket = new Basket();

            Console.WriteLine();
        }

        [Test]
        public void When_AddItem_is_called_then_adds_item()
        {
            _basket.AddItem(1);

            Assert.That(_basket.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void When_AddItem_is_called_then_changes_state_to_ContainsStuff()
        {
            _basket.AddItem(1);

            Assert.That(_basket.State, Is.EqualTo(BasketState.ContainsStuff));
        }

        [Test]
        public void When_RemoveItem_is_called_then_throws_exception()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => _basket.RemoveItem(99));

            Assert.That(exception.Message, Is.EqualTo(EmptyState.REMOVE_ERROR_MESSAGE));
        }

        [Test]
        public void When_CheckOut_is_called_then_throws_exception()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => _basket.CheckOut());

            Assert.That(exception.Message, Is.EqualTo(EmptyState.CHECKOUT_ERROR_MESSAGE));
        }

        [Test]
        public void When_Archive_is_called_then_changes_state_to_Archived()
        {
            _basket.Archive();

            Assert.That(_basket.State, Is.EqualTo(BasketState.Archived));
        }
    }
}
