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

    public enum BasketState
    {
        Empty,
        ContainsStuff,
        CheckedOut,
        Archived
    }
}