using BasketStateMachine.BasketStates;

namespace BasketStateMachine
{
    public class BasketStateFactory : IBasketStateFactory
    {
        public BasketStateBase Create(Basket basket)
        {
            switch (basket.State)
            {
                case BasketState.Empty:
                    return new EmptyStateBase(basket);
                case BasketState.ContainsStuff:
                    return new ContainsStuffState(basket);
                case BasketState.CheckedOut:
                    return new CheckedOutState(basket);
                case BasketState.Archived:
                    return new ArchivedState(basket);
            }

            return null;
        }
    }
}
