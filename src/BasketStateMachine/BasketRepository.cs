using System;

namespace BasketStateMachine
{
    public class BasketRepository : IBasketRepository
    {
        public IBasket Get(int basketId)
        {
            return new Basket { Id = basketId };
        }

        public void Save(IBasket basket)
        {
            Console.Out.WriteLine("BasketRepository.Save called.");
        }

        public void RemoveItem()
        {
            Console.Out.WriteLine("BasketRepository.RemoveItem called.");
        }

        public void Checkout()
        {
            Console.Out.WriteLine("BasketRepository.Checkout called.");
        }

        public void Archive()
        {
            Console.Out.WriteLine("BasketRepository.Archive called.");
        }
    }
}