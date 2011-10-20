using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace BasketStateMachine.Unit.Tests
{
    [TestFixture]
    public class Given_that_state_is_Empty
    {
        private IBasket _basket;
        private IBasketRepository _basketRepository;

        [SetUp]
        public void SetUpTest()
        {
            _basketRepository = MockRepository.GenerateStub<IBasketRepository>();
            _basket = new Basket(_basketRepository);
            Assert.That(_basket.State, Is.EqualTo(BasketState.Empty));
            Console.WriteLine();
        }

        [Test]
        public void When_AddItem_is_called_then_adds_item()
        {
            _basket.AddItem();

            _basketRepository.AssertWasCalled(r=>r.AddItem());
        }

        [Test]
        public void When_AddItem_is_called_then_changes_state_to_ContainsStuff()
        {
            _basket.AddItem();

            Assert.That(_basket.State, Is.EqualTo(BasketState.ContainsStuff));
        }

        [Test]
        public void When_RemoveItem_is_called_then_does_not_remove_item()
        {
            _basket.RemoveItem();

            _basketRepository.AssertWasNotCalled(r => r.RemoveItem());
        }

        [Test]
        public void When_RemoveItem_is_called_then_does_not_change_state()
        {
            _basket.RemoveItem();

            Assert.That(_basket.State, Is.EqualTo(BasketState.Empty));
        }

        [Test]
        public void When_Checkout_is_called_then_does_not_checkout()
        {
            _basket.Checkout();

            _basketRepository.AssertWasNotCalled(r => r.Checkout());
        }

        [Test]
        public void When_Checkout_is_called_then_does_not_change_state()
        {
            _basket.Checkout();

            Assert.That(_basket.State, Is.EqualTo(BasketState.Empty));
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
