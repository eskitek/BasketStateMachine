using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace BasketStateMachine.Unit.Tests
{
    [TestFixture]
    public class Given_that_state_is_ContainsStuff
    {
        private IBasketService _basketService;
        private IBasketRepository _basketRepositoryStub;
        private IBasket _basketStub;

        [SetUp]
        public void SetUpTest()
        {
            _basketStub = MockRepository.GenerateStub<Basket>();
            _basketStub.State = BasketState.ContainsStuff;

            _basketRepositoryStub = MockRepository.GenerateStub<IBasketRepository>();
            _basketRepositoryStub.Stub(r => r.Get(Arg<int>.Is.Anything)).Return(_basketStub);

            _basketService = new BasketService(_basketRepositoryStub);
            _basketService.AddItem(1, 5);
            Console.WriteLine();
        }

        [Test]
        public void When_AddItem_is_called_then_adds_item()
        {
            _basketService.AddItem(1, 5);

            _basketStub.AssertWasCalled(b => b.AddItem(5));
        }

        [Test]
        public void When_AddItem_is_called_then_does_not_change_state()
        {
            _basketService.AddItem(1, 5);

            Assert.That(_basketStub.State, Is.EqualTo(BasketState.ContainsStuff));
        }

        [Test]
        public void When_RemoveItem_is_called_then_removes_item()
        {
            _basketService.RemoveItem(1, 5);

            _basketStub.AssertWasCalled(b => b.RemoveItem(5));
        }

        [Test]
        public void When_RemoveItem_is_called_if_remaining_item_count_is_0_then_changes_state_to_Empty()
        {
            _basketStub.Stub(b => b.ItemCount).Return(0);

            _basketService.RemoveItem(1, 5);

            Assert.That(_basketStub.State, Is.EqualTo(BasketState.Empty));
        }

        [Test]
        public void When_RemoveItem_is_called_if_remaining_item_count_is_greater_than_0_then_does_not_change_state()
        {
            _basketStub.Stub(b => b.ItemCount).Return(1);

            _basketService.RemoveItem(1, 5);

            Assert.That(_basketStub.State, Is.EqualTo(BasketState.ContainsStuff));
        }

        [Test]
        public void When_Checkout_is_called_then_checks_out()
        {
            _basketService.Checkout(1);

            _basketStub.AssertWasCalled(b => b.CheckOut());
        }

        [Test]
        public void When_Checkout_is_called_then_changes_state_to_CheckedOut()
        {
            _basketService.Checkout(1);

            Assert.That(_basketStub.State, Is.EqualTo(BasketState.CheckedOut));
        }

        [Test]
        public void When_Archive_is_called_then_archives()
        {
            _basketService.Archive(1);

            _basketStub.AssertWasCalled(b => b.Archive());
        }

        [Test]
        public void When_Archive_is_called_then_changes_state_to_Archived()
        {
            _basketService.Archive(1);

            Assert.That(_basketStub.State, Is.EqualTo(BasketState.Archived));
        }
    }
}
