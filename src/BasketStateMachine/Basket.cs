using System;

namespace BasketStateMachine
{
    public class Basket : IBasket
    {
        private readonly IBasketRepository _basketRepository;

        private int _itemCount;

        private BasketState _state;

        public BasketState State
        {
            get { return _state; }
            private set
            {
                if(_state == value)
                {
                    return;
                }
                _state = value;
                Console.Out.WriteLine(string.Format(">>State changed to {0}.", _state));
            }
        }

        public Basket(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public void AddItem()
        {
            Console.Out.WriteLine("Basket.AddItem called.");

            if (State == BasketState.Empty ||
                State == BasketState.ContainsStuff)
            {
                _basketRepository.AddItem();
                _itemCount++;
                State = BasketState.ContainsStuff;
            }
        }

        public void RemoveItem()
        {
            Console.Out.WriteLine("Basket.RemoveItem called.");
            if (State == BasketState.ContainsStuff)
            {
                _basketRepository.RemoveItem();
                _itemCount--;

                if (_itemCount == 0)
                {
                    State = BasketState.Empty;
                }
            }
        }

        public void Checkout()
        {
            Console.Out.WriteLine("Basket.Checkout called.");

            if (State == BasketState.ContainsStuff)
            {
                _basketRepository.Checkout();
                State = BasketState.CheckedOut;
            }
        }

        public void Archive()
        {
            Console.Out.WriteLine("Basket.Archive called.");
            _basketRepository.Archive();
            State = BasketState.Archived;
        }
    }
}