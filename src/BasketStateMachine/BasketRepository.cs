using System;

namespace BasketStateMachine
{
    public class BasketRepository : IBasketRepository
    {
        public void AddItem()
        {
            Console.Out.WriteLine("BasketRepository.AddItem called.");
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