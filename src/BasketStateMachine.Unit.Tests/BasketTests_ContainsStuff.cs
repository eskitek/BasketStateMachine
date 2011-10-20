using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace BasketStateMachine.Unit.Tests
{
    [TestFixture]
    public class Given_that_state_is_ContainsStuff
    {
        private IBasket _basket;
        private IBasketRepository _basketRepository;

        [SetUp]
        public void SetUpTest()
        {
            _basketRepository = MockRepository.GenerateStub<IBasketRepository>();
            _basket = new Basket(_basketRepository);
            _basket.AddItem();
            Assert.That(_basket.State, Is.EqualTo(BasketState.ContainsStuff));
            Console.WriteLine();
        }

        [Test]
        public void When_AddItem_is_called_then_adds_item()
        {
            _basket.AddItem();

            _basketRepository.AssertWasCalled(r => r.AddItem());
        }

        [Test]
        public void When_AddItem_is_called_then_does_not_change_state()
        {
            _basket.AddItem();

            Assert.That(_basket.State, Is.EqualTo(BasketState.ContainsStuff));
        }

        [Test]
        public void When_RemoveItem_is_called_then_removes_item()
        {
            _basket.RemoveItem();

            _basketRepository.AssertWasCalled(r => r.RemoveItem());
        }

        [Test]
        public void When_RemoveItem_is_called_if_item_count_is_1_then_changes_state_to_Empty()
        {
            _basket.RemoveItem();

            Assert.That(_basket.State, Is.EqualTo(BasketState.Empty));
        }

        [Test]
        public void When_RemoveItem_is_called_if_item_count_is_greater_than_1_then_does_not_change_state()
        {
            _basket.AddItem();
            _basket.RemoveItem();

            Assert.That(_basket.State, Is.EqualTo(BasketState.ContainsStuff));
        }

        [Test]
        public void When_Checkout_is_called_then_checks_out()
        {
            _basket.Checkout();

            _basketRepository.AssertWasCalled(r => r.Checkout());
        }

        [Test]
        public void When_Checkout_is_called_then_changes_state_to_CheckedOut()
        {
            _basket.Checkout();

            Assert.That(_basket.State, Is.EqualTo(BasketState.CheckedOut));
        }

        [Test]
        public void When_Archive_is_called_then_archives()
        {
            _basket.Archive();

            _basketRepository.AssertWasCalled(r => r.Archive());
        }

        [Test]
        public void When_Archive_is_called_then_changes_state_to_Archived()
        {
            _basket.Archive();

            Assert.That(_basket.State, Is.EqualTo(BasketState.Archived));
        }
    }
}
