using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace BasketStateMachine.Unit.Tests
{
    [TestFixture]
    public class Given_that_state_is_Archived
    {
        private IBasket _basket;
        private IBasketRepository _basketRepositoryMock;

        [SetUp]
        public void SetUpTest()
        {
            Console.WriteLine(@"Setting up test");
            _basketRepositoryMock = MockRepository.GenerateMock<IBasketRepository>();
            _basket = new Basket(_basketRepositoryMock);
            _basket.AddItem();
            _basket.Checkout();
            _basket.Archive();
            Assert.That(_basket.State, Is.EqualTo(BasketState.Archived));

            Console.WriteLine();
            Console.WriteLine(@"Starting test");
        }

        [Test]
        public void When_AddItem_is_called_then_does_not_add_item()
        {
            _basket.AddItem();

            _basketRepositoryMock.Expect(r => r.AddItem()).Repeat.Never();

            _basketRepositoryMock.VerifyAllExpectations();
        }

        [Test]
        public void When_AddItem_is_called_then_does_not_change_state()
        {
            _basket.AddItem();

            Assert.That(_basket.State, Is.EqualTo(BasketState.Archived));
        }

        [Test]
        public void When_RemoveItem_is_called_then_does_not_remove_item()
        {
            _basket.RemoveItem();

            _basketRepositoryMock.AssertWasNotCalled(r => r.RemoveItem());
        }

        [Test]
        public void When_RemoveItem_is_called_does_not_change_state()
        {
            _basket.RemoveItem();

            Assert.That(_basket.State, Is.EqualTo(BasketState.Archived));
        }

        [Test]
        public void When_Checkout_is_called_then_does_not_check_out()
        {
            _basket.Checkout();

            _basketRepositoryMock.Expect(r => r.Checkout()).Repeat.Never();

            _basketRepositoryMock.VerifyAllExpectations();
        }

        [Test]
        public void When_Checkout_is_called_then_does_not_change_state()
        {
            _basket.Checkout();

            Assert.That(_basket.State, Is.EqualTo(BasketState.Archived));
        }

        [Test]
        public void When_Archive_is_called_then_does_not_archive()
        {
            _basket.Archive();

            _basketRepositoryMock.Expect(r => r.Archive()).Repeat.Never();

            _basketRepositoryMock.VerifyAllExpectations();
        }

        [Test]
        public void When_Archive_is_called_then_does_not_change_state()
        {
            _basket.Archive();

            Assert.That(_basket.State, Is.EqualTo(BasketState.Archived));
        }
    }
}
