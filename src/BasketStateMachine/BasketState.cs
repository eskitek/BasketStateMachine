namespace BasketStateMachine
{
    public abstract class BasketStateNew
    {
        protected readonly IBasket _basket;

        protected BasketStateNew(IBasket basket)
        {
            _basket = basket;
        }

        public abstract void AddItem(int itemId);

        public abstract void RemoveItem(int itemId);

        public abstract void CheckOut();

        public abstract void Archive();
    }
}