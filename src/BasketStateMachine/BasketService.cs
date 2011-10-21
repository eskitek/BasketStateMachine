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
            var basket = _basketRepository.Get(basketId);
            basket.AddItem(itemId);
            _basketRepository.Save(basket);
        }

        public void RemoveItem(int basketId, int itemId)
        {
            var basket = _basketRepository.Get(basketId);
            basket.RemoveItem(itemId);
            _basketRepository.Save(basket);
        }

        public void CheckOut(int basketId)
        {
            var basket = _basketRepository.Get(basketId);
            basket.CheckOut();
            _basketRepository.Save(basket);
        }

        public void Archive(int basketId)
        {
            var basket = _basketRepository.Get(basketId);
            basket.Archive(); 
            _basketRepository.Save(basket);
        }
    }
}