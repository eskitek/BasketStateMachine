using System;

namespace BasketStateMachine
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public void AddItem(int basketId, int itemId)
        {
            Console.Out.WriteLine("BasketService.AddItem called.");

            var basket = _basketRepository.Get(basketId);

            if (basket.State == BasketState.Empty ||
                basket.State == BasketState.ContainsStuff)
            {
                basket.AddItem(itemId);
                basket.State = BasketState.ContainsStuff;
                _basketRepository.Save(basket);
            }
        }

        public void RemoveItem(int basketId, int itemId)
        {
            Console.Out.WriteLine("BasketService.RemoveItem called.");

            var basket = _basketRepository.Get(basketId);

            if (basket.State == BasketState.ContainsStuff)
            {
                basket.RemoveItem(itemId);

                if (basket.ItemCount == 0)
                {
                    basket.State = BasketState.Empty;
                }

                _basketRepository.Save(basket);
            }
        }

        public void Checkout(int basketId)
        {
            Console.Out.WriteLine("BasketService.Checkout called.");

            var basket = _basketRepository.Get(basketId);

            if (basket.State == BasketState.ContainsStuff)
            {
                basket.CheckOut();
                basket.State = BasketState.CheckedOut;
                _basketRepository.Save(basket);
            }
        }

        public void Archive(int basketId)
        {
            Console.Out.WriteLine("BasketService.Archive called.");

            var basket = _basketRepository.Get(basketId);

            if (basket.State != BasketState.Archived)
            {
                basket.Archive();
                basket.State = BasketState.Archived;
                _basketRepository.Save(basket);
            }
        }
    }
}