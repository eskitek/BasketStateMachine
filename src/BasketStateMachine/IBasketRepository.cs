namespace BasketStateMachine
{
    public interface IBasketRepository
    {
        void AddItem();
        void RemoveItem();
        void Checkout();
        void Archive();
    }
}