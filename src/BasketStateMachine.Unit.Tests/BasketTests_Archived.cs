using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace BasketStateMachine.Unit.Tests
{
    [TestFixture]
    public class Given_that_state_is_Archived
    {
        private IBasketService _basketService;
        private IBasketRepository _basketRepositoryStub;
        private IBasket _basketStub;

        [SetUp]
        public void SetUpTest()
        {
            _basketStub = MockRepository.GenerateStub<Basket>();
            _basketStub.State = BasketState.Archived;

            _basketRepositoryStub = MockRepository.GenerateStub<IBasketRepository>();
            _basketRepositoryStub.Stub(r => r.Get(Arg<int>.Is.Anything)).Return(_basketStub);

            _basketService = new BasketService(_basketRepositoryStub);

            Console.WriteLine();
            Console.WriteLine(@"Starting test");
        }

        [Test]
        public void When_AddItem_is_called_then_does_not_add_item()
        {
            _basketService.AddItem(1, 5);

            _basketStub.AssertWasNotCalled(b => b.AddItem(5));
        }

        [Test]
        public void When_AddItem_is_called_then_does_not_change_state()
        {
            _basketService.AddItem(1, 5);

            Assert.That(_basketStub.State, Is.EqualTo(BasketState.Archived));
        }

        [Test]
        public void When_RemoveItem_is_called_then_does_not_remove_item()
        {
            _basketService.RemoveItem(1, 5);

            _basketStub.AssertWasNotCalled(r => r.RemoveItem(5));
        }

        [Test]
        public void When_RemoveItem_is_called_does_not_change_state()
        {
            _basketService.RemoveItem(1, 5);

            Assert.That(_basketStub.State, Is.EqualTo(BasketState.Archived));
        }

        [Test]
        public void When_Checkout_is_called_then_does_not_check_out()
        {
            _basketService.Checkout(1);

            _basketStub.AssertWasNotCalled(b => b.CheckOut());
        }

        [Test]
        public void When_Checkout_is_called_then_does_not_change_state()
        {
            _basketService.Checkout(1);

            Assert.That(_basketStub.State, Is.EqualTo(BasketState.Archived));
        }

        [Test]
        public void When_Archive_is_called_then_does_not_archive()
        {
            _basketService.Archive(1);

            _basketStub.AssertWasNotCalled(b => b.Archive());
        }

        [Test]
        public void When_Archive_is_called_then_does_not_change_state()
        {
            _basketService.Archive(1);

            Assert.That(_basketStub.State, Is.EqualTo(BasketState.Archived));
        }
    }
}
