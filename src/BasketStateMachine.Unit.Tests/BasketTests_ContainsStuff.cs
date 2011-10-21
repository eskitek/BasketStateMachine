using System;
using NUnit.Framework;

namespace BasketStateMachine.Unit.Tests
{
    [TestFixture]
    public class Given_that_state_is_ContainsStuff
    {
        private Basket _basket;

        [SetUp]
        public void SetUpTest()
        {
            _basket = new Basket();
            _basket.Items.Add(new BasketItem { Id = 2 });
            _basket.State = BasketState.ContainsStuff;

            Console.WriteLine();
        }

        [Test]
        public void When_AddItem_is_called_then_adds_item()
        {
            _basket.AddItem(1);
            Assert.That(_basket.Items.Count, Is.EqualTo(2));
        }

        [Test]
        public void When_AddItem_is_called_then_does_not_change_state()
        {
            _basket.AddItem(2);
            Assert.That(_basket.State, Is.EqualTo(BasketState.ContainsStuff));
        }

        [Test]
        public void When_RemoveItem_is_called_then_removes_item()
        {
            var itemToRemove = _basket.Items[0];
            _basket.RemoveItem(itemToRemove.Id);
            Assert.That(_basket.Items.Contains(itemToRemove), Is.False);
        }

        [Test]
        public void When_RemoveItem_is_called_if_remaining_item_count_is_0_then_changes_state_to_Empty()
        {
            var itemToRemove = _basket.Items[0];
            _basket.RemoveItem(itemToRemove.Id);
            Assert.That(_basket.Items.Count, Is.EqualTo(0));
            Assert.That(_basket.State, Is.EqualTo(BasketState.Empty));
        }

        [Test]
        public void When_RemoveItem_is_called_if_remaining_item_count_is_greater_than_0_then_does_not_change_state()
        {
            _basket.AddItem(3);
            var itemToRemove = _basket.Items[0];
            _basket.RemoveItem(itemToRemove.Id);
            Assert.That(_basket.Items.Count, Is.GreaterThan(0));
            Assert.That(_basket.State, Is.EqualTo(BasketState.ContainsStuff));
        }

        [Test]
        public void When_Checkout_is_called_then_changes_state_to_CheckedOut()
        {
            _basket.CheckOut();

            Assert.That(_basket.State, Is.EqualTo(BasketState.CheckedOut));
        }

        [Test]
        public void When_Archive_is_called_then_changes_state_to_Archived()
        {
            _basket.Archive();

            Assert.That(_basket.State, Is.EqualTo(BasketState.Archived));
        }
    }
}
