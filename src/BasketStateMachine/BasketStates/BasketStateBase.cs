namespace BasketStateMachine.BasketStates
{
    public abstract class BasketStateBase
    {
        protected readonly IBasket _basket;

        protected BasketStateBase(IBasket basket)
        {
            _basket = basket;
        }

        public abstract void AddItem(int itemId);

        public abstract void RemoveItem(int itemId);

        public abstract void CheckOut();

        public abstract void Archive();
    }
}