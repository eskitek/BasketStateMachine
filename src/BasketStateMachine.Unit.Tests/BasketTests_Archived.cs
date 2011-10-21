using System;
using NUnit.Framework;

namespace BasketStateMachine.Unit.Tests
{
    [TestFixture]
    public class Given_that_state_is_Archived
    {
        private Basket _basket;

        [SetUp]
        public void SetUpTest()
        {
            _basket = new Basket();
            _basket.Items.Add(new BasketItem { Id = 2 });
            _basket.State = BasketState.Archived;

            Console.WriteLine();
        }

        [Test]
        public void When_AddItem_is_called_then_throws_exception()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => _basket.AddItem(99));

            Assert.That(exception.Message, Is.EqualTo(ArchivedState.ADD_ERROR_MESSAGE));
        }

        [Test]
        public void When_RemoveItem_is_called_then_throws_exception()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => _basket.RemoveItem(99));

            Assert.That(exception.Message, Is.EqualTo(ArchivedState.REMOVE_ERROR_MESSAGE));
        }

        [Test]
        public void When_CheckOut_is_called_then_throws_exception()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => _basket.CheckOut());

            Assert.That(exception.Message, Is.EqualTo(ArchivedState.CHECKOUT_ERROR_MESSAGE));
        }

        [Test]
        public void When_Archive_is_called_then_throws_exception()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => _basket.Archive());

            Assert.That(exception.Message, Is.EqualTo(ArchivedState.ARCHIVE_ERROR_MESSAGE));
        }
    }
}
