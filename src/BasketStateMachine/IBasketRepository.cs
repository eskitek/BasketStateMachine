namespace BasketStateMachine
{
	public interface IBasketRepository
	{
		IBasket Get(int basketId);
		void Save(IBasket basket);
		void RemoveItem();
		void Checkout();
		void Archive();
	}
}