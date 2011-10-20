namespace BasketStateMachine
{
    public interface IBasket
    {
        void AddItem();

        void RemoveItem();

        void Checkout();

        void Archive();

        BasketState State { get; }
    }

    public interface IBasketRepository
    {
        void AddItem();
        void RemoveItem();

        object Checkout();

        object Archive();
    }

    public enum BasketState
    {
        Empty,
        ContainsStuff,
        CheckedOut,
        Archived
    }
}