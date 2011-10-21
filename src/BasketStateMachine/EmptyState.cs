using System;

namespace BasketStateMachine
{
    public class EmptyState : BasketStateNew
    {
        public const string REMOVE_ERROR_MESSAGE = "Can't remove an item from an empty basket.";
        public const string CHECKOUT_ERROR_MESSAGE = "Can't check out an empty basket.";

        public EmptyState(IBasket basket)
            : base(basket)
        {
        }

        public override void AddItem(int itemId)
        {
            var item = new BasketItem { Id = itemId };
            _basket.Items.Add(item);
            _basket.State = BasketState.ContainsStuff;
        }

        public override void RemoveItem(int itemId)
        {
            throw new InvalidOperationException(REMOVE_ERROR_MESSAGE);
        }

        public override void CheckOut()
        {
            throw new InvalidOperationException(CHECKOUT_ERROR_MESSAGE);
        }

        public override void Archive()
        {
            _basket.State = BasketState.Archived;
        }
    }
}