using BasketStateMachine.BasketStates;

namespace BasketStateMachine
{
    public interface IBasketStateFactory
    {
        BasketStateBase Create(Basket basket);
    }
}