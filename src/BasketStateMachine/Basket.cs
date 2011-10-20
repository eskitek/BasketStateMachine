using System;

namespace BasketStateMachine
{
    public class Basket : IBasket
    {
        private readonly IBasketRepository _basketRepository;

        private int _itemCount;

        public Basket(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
            Console.Out.WriteLine(string.Format(">>State initilised to {0}.", State));
        }

        public void AddItem()
        {
            Console.Out.WriteLine("AddItem called.");
            _itemCount++;
            Console.Out.WriteLine(">>Added item to basket.");
            _basketRepository.AddItem();
            State = BasketState.ContainsStuff;
            Console.Out.WriteLine(string.Format(">>Changed state to {0}.", State));
        }

        public void RemoveItem()
        {
            Console.Out.WriteLine("RemoveItem called.");
            if (State == BasketState.ContainsStuff)
            {
                _itemCount--;
                _basketRepository.RemoveItem();
                Console.Out.WriteLine(">>Removed item from basket.");

                if (_itemCount == 0)
                {
                    State = BasketState.Empty;
                    Console.Out.WriteLine(string.Format(">>Changed state to {0}.", State));
                }
            }
        }

        public void Checkout()
        {
            Console.Out.WriteLine("Checkout called.");

            if (State == BasketState.ContainsStuff)
            {
                _basketRepository.Checkout();
                Console.Out.WriteLine(">>Checked out basket.");
                State = BasketState.CheckedOut;
                Console.Out.WriteLine(string.Format(">>Changed state to {0}.", State));
            }
        }

        public void Archive()
        {
            Console.Out.WriteLine("Archive called.");
            _basketRepository.Archive();
            Console.Out.WriteLine(">>Archived basket.");
            State = BasketState.Archived;
            Console.Out.WriteLine(string.Format(">>Changed state to {0}.", State));
        }

        public BasketState State
        {
            get;
            private set;
        }
    }
}