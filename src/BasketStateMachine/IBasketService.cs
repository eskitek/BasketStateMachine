namespace BasketStateMachine
{
	public interface IBasketService
	{
		void AddItem(int basketId, int itemId);

		void RemoveItem(int basketId, int itemId);

		void CheckOut(int basketId);

		void Archive(int basketId);
	}
}