using System;
using BasketStateMachine.BasketStates;
using NUnit.Framework;

namespace BasketStateMachine.Unit.Tests
{
    [TestFixture]
    public class Given_that_state_is_CheckedOut
    {
        private Basket _basket;

        [SetUp]
        public void SetUpTest()
        {
            _basket = new Basket();
            _basket.Items.Add(new BasketItem { Id = 2 });
            _basket.State = BasketState.CheckedOut;

            Console.WriteLine();
        }

        [Test]
        public void When_AddItem_is_called_then_throws_exception()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => _basket.AddItem(99));

            Assert.That(exception.Message, Is.EqualTo(CheckedOutState.ADD_ERROR_MESSAGE));
        }

        [Test]
        public void When_RemoveItem_is_called_then_throws_exception()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => _basket.RemoveItem(99));

            Assert.That(exception.Message, Is.EqualTo(CheckedOutState.REMOVE_ERROR_MESSAGE));
        }

        [Test]
        public void When_CheckOut_is_called_then_throws_exception()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => _basket.CheckOut());

            Assert.That(exception.Message, Is.EqualTo(CheckedOutState.CHECKOUT_ERROR_MESSAGE));
        }

        [Test]
        public void When_Archive_is_called_then_changes_state_to_Archived()
        {
            _basket.Archive();

            Assert.That(_basket.State, Is.EqualTo(BasketState.Archived));
        }
    }
}
