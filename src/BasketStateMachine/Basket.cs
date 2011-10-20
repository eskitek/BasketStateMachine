using System;

namespace BasketStateMachine
{
    public class Basket : IBasket
    {
        public void AddItem()
        {
            ItemCount++;
            Console.Out.WriteLine("Item added to basket.");
            State = BasketState.ContainsStuff;
        }

        public void RemoveItem()
        {
            if (ItemCount <= 0)
            {
                return;
            }

            ItemCount--;
            Console.Out.WriteLine("Item removed from basket.");

            if (ItemCount == 0)
            {
                State = BasketState.Empty;
            }
        }

        protected int ItemCount { get; private set; }

        public void Checkout()
        {
        }

        public void Archive()
        {
            State = BasketState.Archived;
        }

        public BasketState State
        {
            get;
            private set;
        }
    }
}